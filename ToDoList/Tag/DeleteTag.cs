using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class DeleteTag : Form
    {
        public List<Tag> Tags { get; set; }

        public DeleteTag(ToDoContext toDoContext)
        {
            InitializeComponent();
            Tags = new List<Tag>();
            foreach (var tag in toDoContext.Tags)
            {
                TagsComboBox.Items.Add(tag);
                Tags.Add(tag);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TagsComboBox.SelectedIndex >= 0)
            {
                try
                {
                    foreach (var item in Tags)
                    {
                        if (item == TagsComboBox.SelectedItem)
                        {
                            var dialogResult = MessageBox.Show("\nAre you sure you want to delete this tag?", "Delete tag", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Tags.Remove(item);
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
                MessageBox.Show("You didn't choose tag!");
            }
        }
    }
}