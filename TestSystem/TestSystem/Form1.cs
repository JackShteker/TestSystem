using System;
using System.Windows.Forms;
namespace TestSystem
{
    public partial class Form1 : Form
    {
        TaskList taskList = new TaskList();
        bool[] correctAnswers = new bool[50];
        byte index;
        public Form1()
        {
            InitializeComponent();

        }
        public override void  Refresh()
        {
            radioAnswer1.Visible = true;
            radioAnswer2.Visible = true;
            radioAnswer3.Visible = true;
            radioAnswer4.Visible = true;
            radioAnswer5.Visible = true;
            radioAnswer6.Visible = true;
            radioAnswer7.Visible = true;
            labelCode.Text = "";
            string[] k3k = taskList.GetTask(index).GetCodeSample();
            labelTask.Text = taskList.GetTask(index).GetQuestion();
            foreach (string element in k3k)
                labelCode.Text = labelCode.Text + element + Environment.NewLine;
            string[] answers = taskList.GetTask(index).GetAnswers();
            PrintAns(radioAnswer1, answers[0]);
            PrintAns(radioAnswer2, answers[1]);
            PrintAns(radioAnswer3, answers[2]);
            PrintAns(radioAnswer4, answers[3]);
            PrintAns(radioAnswer5, answers[4]);
            PrintAns(radioAnswer6, answers[5]);
            PrintAns(radioAnswer7, answers[6]);
        }
        private string CountScore()
        {
            int counter = 0;
            for (int i = 0; i < taskList.Len(); i++)
                if (correctAnswers[i]) counter++;
            return (counter.ToString() + "/" + taskList.Len());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = SystemInformation.VirtualScreen.Width;
            this.Height = SystemInformation.VirtualScreen.Height;
            tableLayoutPanel1.Width = this.Width - 100;
            tableLayoutPanel1.Height = this.Height - 100;
            index = 0;
            // MessageBox.Show(taskList.GetTask(0).GetAnswers()[0]);
            // MessageBox.Show(taskList.GetTask(1).GetAnswers()[0]);
            Refresh();
        }
        public void RadioCheck(RadioButton radioAnswer)
        {
            if (radioAnswer.Checked)
            {
                if (taskList.GetTask(index).SendAnswer(radioAnswer.Text))
                {
                    correctAnswers[index] = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            RadioCheck(radioAnswer1);
            RadioCheck(radioAnswer2);
            RadioCheck(radioAnswer3);
            RadioCheck(radioAnswer4);
            RadioCheck(radioAnswer5);
            RadioCheck(radioAnswer6);
            RadioCheck(radioAnswer7);
            if (index == 1) MessageBox.Show(CountScore());
            else
            {
                index++;
                Refresh();
            }
        }
        private void PrintAns(RadioButton radioAnswer, string answer)
        {
            if (answer != "-")
            {
                radioAnswer.Text = answer;
            }
            else
            {
                radioAnswer.Visible = false;
            }
        }
    }
}
