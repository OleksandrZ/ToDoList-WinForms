using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class DeleteCategory : Form
    {
        public List<Category> Categories { get; set; }

        public DeleteCategory(ToDoContext toDoContext)
        {
            InitializeComponent();
            Categories = new List<Category>();
            foreach (var item in toDoContext.Categories)
            {
                CategoryComboBox.Items.Add(item);
                Categories.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedIndex >= 0)
            {
                try
                {
                    foreach (var item in Categories)
                    {
                        if (item == CategoryComboBox.SelectedItem)
                        {
                            var dialogResult = MessageBox.Show("If you delete this category some records might be erased. \nAre you sure?", "Delete category", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Categories.Remove(item);
                                break;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You didn't choose category!");
            }
        }
    }
}