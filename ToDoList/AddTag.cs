using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class AddTag : Form
    {
        public string NewTag { get; set; }

        public AddTag()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NewTag.Length > 3)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Tag must be at least 4 symbols!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NewTag = textBox1.Text;
        }
    }
}