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
            dataGridView1.DataSource = new ObjectRecipesService().GetAll();
        }
    }
}
