using System;
using System.Windows.Forms;
namespace TestSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Hello Yarolav");
            TaskList taskList = new TaskList();
            MessageBox.Show(taskList.GetTask(1).GetQuestion());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = this.Width;
            tableLayoutPanel1.Height = this.Height;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
