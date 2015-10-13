using System;
using System.Windows.Forms;
namespace TestSystem
{
    public partial class Form1 : Form
    {
        TaskList taskList = new TaskList();
        bool [] correctAnswers = new bool [50];
        byte index;
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
            this.Width = SystemInformation.VirtualScreen.Width;
            this.Height = SystemInformation.VirtualScreen.Height;
            tableLayoutPanel1.Width = this.Width-100;
            tableLayoutPanel1.Height = this.Height-100;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioAnswer1.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer1.Text))
                {
                    correctAnswers[index] = true;
                }
            }
            else if (radioAnswer2.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer2.Text))
                {
                    correctAnswers[index] = true;
                }
            }
            else if (radioAnswer3.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer3.Text))
                {
                    correctAnswers[index] = true;
                }        
            }
            else if (radioAnswer4.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer4.Text))
                {
                    correctAnswers[index] = true;
                }         
            }
            else if (radioAnswer5.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer5.Text))
                {
                    correctAnswers[index] = true;
                }
            }
            else if (radioAnswer6.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer6.Text))
                {
                    correctAnswers[index] = true;
                }
            }
            else if (radioAnchor7.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnchor7.Text))
                {
                    correctAnswers[index] = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Lines = taskList.GetTask(1).GetCodeSample();
            string[] answers = taskList.GetTask(1).GetAnswers();
            radioAnswer1.Text = answers[0];
            radioAnswer2.Text = answers[1];
            radioAnswer3.Text = answers[2];
            radioAnswer4.Text = answers[3];
            radioAnswer5.Text = answers[4];
            radioAnswer6.Text = answers[5];
            radioAnchor7.Text = answers[6];
        }
    }
}
