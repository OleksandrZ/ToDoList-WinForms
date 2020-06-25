using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoEditAdd : Form
    {
        public ToDo toDo { get; set; }
        private ToDoContext toDoContext;
        private Dictionary<Button, ComboBox> addedTags;
        private Point point = new Point(0, 0);

        public ToDoEditAdd(ToDoContext toDoContext, ToDo toDo)
        {
            InitializeComponent();
            this.Text = "Edit";
            this.toDoContext = toDoContext;
            this.toDo = toDo;
            addedTags = new Dictionary<Button, ComboBox>();
            FillForm();
        }

        public ToDoEditAdd(ToDoContext toDoContext)
        {
            InitializeComponent();
            this.Text = "Add";
            this.toDoContext = toDoContext;
            addedTags = new Dictionary<Button, ComboBox>();
            LoadCategoriesAndStatuses();
        }

        private void FillForm()
        {
            nameBox.Text = toDo.Name;
            descriptionBox.Text = toDo.Description;

            priorityNumeric.Value = toDo.Priority;

            DateTime dateTime = toDo.FinalDate;
            dateTimePicker1.Value = dateTime;

            LoadCategoriesAndStatuses();
            LoadTags();
        }

        private void LoadCategoriesAndStatuses()
        {
            foreach (var item in toDoContext.Categories)
            {
                categoryComboBox.Items.Add(item);
                if (toDo != null && toDo.Category.Name.Equals(item.ToString()))
                {
                    categoryComboBox.SelectedItem = item;
                }
            }
            foreach (var item in toDoContext.Statuses)
            {
                statusComboBox.Items.Add(item);
                if (toDo != null && item.Name.Equals(toDo.status.ToString()))
                {
                    statusComboBox.SelectedItem = item;
                }
            }
        }

        private void LoadTags()
        {
            if (toDo.Tags.Count > 0)
            {
                foreach (var tag in toDo.Tags)
                {
                    CreateTag();
                    ComboBox comboBox = addedTags.Values.Last();
                    foreach (var item in comboBox.Items)
                    {
                        if (item.ToString() == tag.ToString())
                        {
                            comboBox.SelectedItem = item;
                        }
                    }
                }
            }
        }

        private void CreateTag()
        {
            var cb = new ComboBox() { Height = 20, Width = tagPanel.Width - 50 };
            var b = new Button() { Height = 20, Width = 20, Text = "X" };
            b.Click += new EventHandler(DeleteTag);

            addedTags.Add(b, cb);
            string[] selectedTags = new string[addedTags.Values.Count];

            foreach (var tag in toDoContext.Tags)
            {
                cb.Items.Add(tag);
            }

            tagPanel.Controls.Add(cb);
            tagPanel.Controls.Add(b);
            SizeAndLocationForTags(25, 4);
        }

        private void DeleteTag(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int index = 0;
                foreach (var item in addedTags.Keys)
                {
                    if (item == button)
                    {
                        break;
                    }
                    index++;
                }
                tagPanel.Controls.Remove(addedTags.Keys.ElementAt(index));
                tagPanel.Controls.Remove(addedTags.Values.ElementAt(index));
                addedTags.Remove(button);
                SizeAndLocationForTags(-25, 3);
            }
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            CreateTag();
        }

        //lastForPanel нужен из-за того что панель перестает увеличиваться
        //когда добавляется 4 тег и больше, а начинает уменьшатся когда удаляется 3 тег и меньше
        private void SizeAndLocationForTags(int size, int lastForPanel)
        {
            if (addedTags.Count < lastForPanel)
            {
                tagPanel.Height += size;
                addTagButton.Location = new Point(addTagButton.Location.X, addTagButton.Location.Y + size);
                saveAndClose.Location = new Point(saveAndClose.Location.X, saveAndClose.Location.Y + size);
                this.Height += size;
            }

            foreach (var item in addedTags.Values)
            {
                item.Location = new Point(point.X, point.Y);
                point.Y += 25;
            }
            point.Y = 0;
            point.X = tagPanel.Width - 40;
            foreach (var item in addedTags.Keys)
            {
                item.Location = new Point(point.X, point.Y);
                point.Y += 25;
            }
            point.X = 0;
            point.Y = 0;
        }

        private void saveAndClose_Click(object sender, EventArgs e)
        {
            //Если добавление, а не изменение то происходит инициализация поля
            if (toDo == null)
            {
                toDo = new ToDo();
            }
            if (nameBox.Text == "" || descriptionBox.Text == "" || categoryComboBox.SelectedIndex < 0 || statusComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("You need to fill in all the following values: Name, Description, Category and status");
                return;
            }
            toDo.Name = nameBox.Text;
            toDo.Priority = (int)priorityNumeric.Value;
            for (int i = addedTags.Count - 1; i >= 0; i--)
            {
                if (addedTags.Values.ToList()[i].SelectedIndex < 0)
                {
                    addedTags.Remove(addedTags.Keys.ToList()[i]);
                }
            }
            List<Tag> List = new List<Tag>();
            foreach (var item in addedTags.Values)
            {
                List.Add((Tag)item.SelectedItem);
            }
            toDo.Tags = List;
            toDo.Description = descriptionBox.Text;
            toDo.Category = (Category)categoryComboBox.SelectedItem;
            toDo.FinalDate = dateTimePicker1.Value;
            toDo.status = (Status)statusComboBox.SelectedItem;
            this.Close();
        }
    }
}