using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestSystem
{   
    
    public class TaskList
    {
        class Task
        {
            private string Question;
            private string [] Ans = new string[5];
            Task(string Question, string Ans1, string Ans2, string Ans3, string Ans4, string Ans5)
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
        byte current = 1;
        Task[] Tasks = new Task[50];
        public TaskList()
        {

            using (FileStream fileStream = File.Open((string.Join(Directory.GetCurrentDirectory(),"\\Tasks.txt"), FileMode.Open)
            {
                string line;
                int current = 0;
                string[] lines = new string [6];
                while (fileStream.Peek() != null)
                {
                    for(int i = 0; i < 6; i++)
                    {
                        lines[i] = fileStream.ReadLine();
                    }
                    Tasks[current] = Task(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5]);
                    current++;
                }
            }
        }

    }
}
