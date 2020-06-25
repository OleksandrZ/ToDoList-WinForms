using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private ToDoContext toDoContext = new ToDoContext();

        //Так как у CheckedListBox нет ивента на после смены состаяния в checked или unchecked
        //то срабатывает ивент на перед сменой состояния и в эти переменные записывается новое состояние
        private List<Category> checkedCategories = new List<Category>();

        private List<Tag> checkedTags = new List<Tag>();

        public Form1()
        {
            InitializeComponent();
            FillFilters();
            ShowList();
        }

        private void ShowList()
        {
            try
            {
                var result = toDoContext.ToDos
                    .Include(cat => cat.Category)
                    .Include(st => st.status)
                    .Include(tag => tag.Tags)
                    .OrderBy(pri => pri.Priority)
                    .ThenBy(sta => sta.status);

                toDoListView.Items.Clear();
                ListViewItem listViewItem;
                bool[] isContained = new bool[checkedTags.Count];
                //отображение элементов списка дел с учетом поставленных фильтров
                foreach (var item in result)
                {
                    if (checkedCategories.Count != 0 && checkedTags.Count != 0)
                    {
                        if (checkedCategories.Contains(item.Category))
                        {
                            var allOfList1IsInList2 = !checkedTags.Except(item.Tags).Any();
                            if (allOfList1IsInList2)
                            {
                                Add(item, out listViewItem);
                            }
                        }
                    }
                    else if (checkedCategories.Count != 0 && checkedTags.Count == 0)
                    {
                        if (checkedCategories.Contains(item.Category))
                        {
                            Add(item, out listViewItem);
                        }
                    }
                    else if (checkedCategories.Count == 0 && checkedTags.Count != 0)
                    {
                        if (checkedTags.Where(tag => tag.Name == "No tags").Any() && !item.Tags.Any())
                        {
                            Add(item, out listViewItem);
                            break;
                        }
                        var allOfList1IsInList2 = !checkedTags.Except(item.Tags).Any();
                        if (allOfList1IsInList2)
                        {
                            Add(item, out listViewItem);
                        }
                    }
                    else
                    {
                        Add(item, out listViewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Add(ToDo item, out ListViewItem listViewItem)
        {
            listViewItem = new ListViewItem(item.Name);
            listViewItem.SubItems.Add(item.Description);
            listViewItem.SubItems.Add(item.Category.Name);
            listViewItem.SubItems.Add(item.Priority.ToString());
            listViewItem.SubItems.Add(item.FinalDate.ToString());
            listViewItem.SubItems.Add(item.status.Name);

            StringBuilder stringBuilder = new StringBuilder("");
            if (item.Tags.Count > 0)
            {
                Tag last = item.Tags.Last();
                foreach (var tag in item.Tags)
                {
                    if (tag.Equals(last))
                    {
                        stringBuilder.Append(tag.ToString());
                    }
                    else
                    {
                        stringBuilder.Append(tag.ToString() + ", ");
                    }
                }
                listViewItem.SubItems.Add(stringBuilder.ToString());
            }
            listViewItem.Tag = item;

            toDoListView.Items.Add(listViewItem);
        }

        private void FillFilters()
        {
            categoryFilter.Items.Clear();
            tagsFilter.Items.Clear();
            foreach (var item in toDoContext.Categories)
            {
                categoryFilter.Items.Add(item);
            }
            foreach (var item in toDoContext.Tags)
            {
                tagsFilter.Items.Add(item);
            }
            tagsFilter.Items.Add(new Tag { Name = "No tags" });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            toDoContext.Dispose();
        }

        private void AddToDo_Click(object sender, EventArgs e)
        {
            try
            {
                ToDoEditAdd toDoAdd = new ToDoEditAdd(toDoContext);
                toDoAdd.ShowDialog();
                if (toDoAdd.toDo != null)
                {
                    toDoContext.ToDos.Add(toDoAdd.toDo);
                    toDoContext.SaveChanges();
                    ShowList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AddCategory addCategory = new AddCategory();
                addCategory.ShowDialog();
                bool isExist = false;
                foreach (var item in toDoContext.Categories)
                {
                    if (item.Name == addCategory.Category)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    toDoContext.Categories.Add(new Category { Name = addCategory.Category });
                    toDoContext.SaveChanges();
                    FillFilters();
                }
                else
                {
                    MessageBox.Show("Such category already exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteCategory deleteCategory = new DeleteCategory(toDoContext);
                deleteCategory.ShowDialog();

                if (deleteCategory.Categories.Count != toDoContext.Categories.Count())
                {
                    foreach (var item in toDoContext.Categories)
                    {
                        if (!deleteCategory.Categories.Contains(item))
                        {
                            toDoContext.Categories.Remove(item);
                        }
                    }
                    toDoContext.SaveChanges();
                    ShowList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toDoListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (toDoListView.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete this record?", "Delete record", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                ToDo toDo = toDoListView.SelectedItems[0].Tag as ToDo;
                if (toDo != null)
                {
                    toDoContext.ToDos.Remove(toDoContext.ToDos.Find(toDo.Id));
                    toDoContext.SaveChanges();
                    ShowList();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToDo toDo = toDoListView.SelectedItems[0].Tag as ToDo;
                if (toDo != null)
                {
                    ToDoEditAdd toDoEdit = new ToDoEditAdd(toDoContext, toDo);
                    toDoEdit.ShowDialog();

                    var toDoOld = toDoContext.ToDos
                                             .Where(d => d.Id == toDoEdit.toDo.Id)
                                             .FirstOrDefault();
                    toDoOld.Category = toDoEdit.toDo.Category;
                    toDoOld.Description = toDoEdit.toDo.Description;
                    toDoOld.FinalDate = toDoEdit.toDo.FinalDate;
                    toDoOld.Name = toDoEdit.toDo.Name;
                    toDoOld.Priority = toDoEdit.toDo.Priority;
                    toDoOld.status = toDoEdit.toDo.status;

                    //delete old tags and add edited tags
                    var firstToDO = toDoContext.ToDos.Find(toDoEdit.toDo.Id);
                    toDoContext.Entry(firstToDO).Collection(x => x.Tags).Load();
                    firstToDO.Tags = toDoEdit.toDo.Tags;

                    toDoContext.SaveChanges();
                    ShowList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void categoryFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                checkedCategories.Add((Category)categoryFilter.Items[e.Index]);
            else
                checkedCategories.Remove((Category)categoryFilter.Items[e.Index]);

            ShowList();
        }

        private void tagsFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                checkedTags.Add((Tag)tagsFilter.Items[e.Index]);
            else
                checkedTags.Remove((Tag)tagsFilter.Items[e.Index]);

            ShowList();
        }

        //Сброс всех фильтров
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tagsFilter.Items.Count; i++)
            {
                tagsFilter.SetItemChecked(i, false);
            }
            for (int i = 0; i < categoryFilter.Items.Count; i++)
            {
                categoryFilter.SetItemChecked(i, false);
            }
        }

        //Добавление тега
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                AddTag addTag = new AddTag();
                addTag.ShowDialog();
                bool isExist = false;
                foreach (var item in toDoContext.Tags)
                {
                    if (item.Name == addTag.NewTag)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    toDoContext.Tags.Add(new Tag { Name = addTag.NewTag });
                    toDoContext.SaveChanges();
                    FillFilters();
                }
                else
                {
                    MessageBox.Show("Such tag already exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteTag_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTag deleteTag = new DeleteTag(toDoContext);
                deleteTag.ShowDialog();

                if (deleteTag.Tags.Count != toDoContext.Tags.Count())
                {
                    foreach (var item in toDoContext.Tags)
                    {
                        if (!deleteTag.Tags.Contains(item))
                        {
                            toDoContext.Tags.Remove(item);
                        }
                    }
                    toDoContext.SaveChanges();
                    ShowList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}