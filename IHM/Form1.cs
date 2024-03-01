using System;
using System.Windows.Forms;
using Services;

namespace IHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
                dataGridView1.DataSource = RecipesServiceFactory.Instance?.GetAll();
            else
                dataGridView1.DataSource = RecipesServiceFactory.Instance?.GetByTitle(textBox1.Text);
        }
    }
}
