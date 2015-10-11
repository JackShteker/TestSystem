using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TestSystem
{   
    
    public class TaskList
    {
        class Task
        {
            private string Question;
            private string [] Ans = new string[5];
            public Task(string Question, string Ans1, string Ans2, string Ans3, string Ans4, string Ans5)
            {
                this.Question = Question;
                this.Ans[0] = Ans1;
                this.Ans[1] = Ans2;
                this.Ans[2] = Ans3;
                this.Ans[3] = Ans4;
                this.Ans[4] = Ans5;
            }
            public string GetQuestion()
            {
                return Question;
            } 
            public string [] GetAnswers()
            {
                Random rand = new Random();
                string[] str = this.Ans.OrderBy(x => rand.Next()).ToArray();
                Array.Resize(ref str, 5);
                return new string[] { str[0], str[1], str[2], str[3], str[4] };
            }      
        }
        Task[] Tasks = new Task[50];
        public TaskList()
        {
            MessageBox.Show(Directory.GetCurrentDirectory());
            using (StreamReader readStream = new StreamReader(Directory.GetCurrentDirectory()+"\\Tasks.txt"))
            {
                int current = 0;
                string[] lines = new string[6];
                while (readStream.Peek() != -1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        lines[i] = readStream.ReadLine();
                    }

                    Tasks[current] = new Task(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5]);
                    current++;
                    MessageBox.Show(Tasks[current-1].GetAnswers()[0]+ Tasks[current - 1].GetAnswers()[1] + Tasks[current - 1].GetAnswers()[2] + Tasks[current - 1].GetAnswers()[3] + Tasks[current - 1].GetAnswers()[4]);
                }
            }
        }

    }
}
