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
       public  class Task
        {
            private string Question;
            private string [] Ans = new string[7];
            private string[] codeSample = new string[9];
            public Task(string Question, string[] codeSample, string[] Answers)
            {
                this.Question = Question;
                this.codeSample = codeSample;
                this.Ans = Answers;
            }
            public string GetQuestion()
            {
                return Question;
            } 
            public string [] GetCodeSample()
            {
                return codeSample;
            }
            public string [] GetAnswers()
            {
                Random rand = new Random();
                string[] str = this.Ans.OrderBy(x => rand.Next()).ToArray();
                Array.Resize(ref str, 7);
                return str;
            }
            public bool SendAnswer(string ans)
            {
                if (ans != Ans[0]) { return false; }
                else { return true; }
            }  
        }
        private Task[] Tasks = new Task[50];
        public TaskList()
        {
           // MessageBox.Show(Directory.GetCurrentDirectory());
            using (StreamReader readStream = new StreamReader(Directory.GetCurrentDirectory()+"\\Tasks.txt"))
            {
                int current = 0;
                string[] lines = new string[7];
                string[] code = new string[9];
                string Quest;
                while (readStream.Peek() != -1)
                {
                    Quest = readStream.ReadLine();
                    int j = 0;
                    code[j] = readStream.ReadLine();
                    j++;
                    while (code[j-1][0] != '&')
                    { 
                        code[j] = readStream.ReadLine();
                        j++;                                    
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        lines[i] = readStream.ReadLine();
                    }

                    Tasks[current] = new Task(Quest, code, lines);
                    current++;
                    //MessageBox.Show(Tasks[current-1].GetAnswers()[0]+ Tasks[current - 1].GetAnswers()[1] + Tasks[current - 1].GetAnswers()[2] + Tasks[current - 1].GetAnswers()[3] + Tasks[current - 1].GetAnswers()[4]);
                }
            }
        }
        public Task GetTask(byte index)
        {
            return Tasks[index];
        }
        public int Len()
        {
            return Tasks.Length;
        }
    }
}
