using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

namespace TestSystem
{
    public partial class Form1 : Form
    {
        public class RandomTask
        {
            private static Random rng = new Random();
            List <int> Tasks = new List<int>();
            int length;
            public RandomTask(int length)
            {

                this.length = length;
                for(int i=0; i<length; i++)
                {
                    Tasks.Add(i);
                }
                int n = Tasks.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    int value = Tasks[k];
                    Tasks[k] = Tasks[n];
                    Tasks[n] = value;
                }
            }
            public int GetTask(int num)
            {
                return Tasks[num];
            }

        }
        static TaskList taskList = new TaskList();
        RandomTask randomTask = new RandomTask(taskList.Len());
        bool[] correctAnswers = new bool[50];
        byte index;
        public string secondName = "";
        public string form = "";
        public Form1()
        {
            InitializeComponent();

        }
        public void SendEmail()
        {
            var fromAddress = new MailAddress("vova.gleb.testsystem@gmail.com", "Vova_Gleb_TestSystem");
            var toAddress = new MailAddress("glebun2@gmail.com", "Irina Sklyar");
            const string fromPassword = "nanomandarin1488";
            string subject = "Test Score";
            string body =  secondName+form+ "\n"+ "Оцiнка "+CountScore();

        var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
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
            string[] k3k = taskList.GetTask(randomTask.GetTask(index)).GetCodeSample();
            labelTask.Text = taskList.GetTask(randomTask.GetTask(index)).GetQuestion();
            foreach (string element in k3k)
                labelCode.Text = labelCode.Text + element + Environment.NewLine;
            string[] answers = taskList.GetTask(randomTask.GetTask(index)).GetAnswers();
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
            return (((counter*12)/taskList.Len()).ToString());
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
            Enabled = false;
            AuthorisationForm subForm = new AuthorisationForm(this);
            subForm.Show();
            
        }
        public void RadioCheck(RadioButton radioAnswer)
        {
            if (radioAnswer.Checked)
            {
                if (taskList.GetTask(randomTask.GetTask(index)).SendAnswer(radioAnswer.Text))
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
            if (index == taskList.Len()-1)
            {
                //MessageBox.Show(CountScore());
                SendEmail();
                Application.Exit();
            }
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
