using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class AddCategory : Form
    {
        public string Category { get; set; }

        public AddCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Category.Length > 3)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Category must be at least 4 symbols!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Category = textBox1.Text;
        }
    }
}