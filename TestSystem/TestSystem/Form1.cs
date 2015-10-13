using System;
using System.Windows.Forms;
namespace TestSystem
{
    public partial class Form1 : Form
    {
        TaskList taskList = new TaskList();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Hello Yarolav");
           // TaskList taskList = new TaskList();
           //MessageBox.Show(taskList.GetTask(1).GetQuestion());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = this.Width;
            tableLayoutPanel1.Height = this.Height;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = taskList.GetTask(1).GetQuestion();
            string[] answers = taskList.GetTask(1).GetAnswers();
            radioAnswer1.Text = answers[0];
        }
    }
}
