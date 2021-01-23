    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<QuestionAnswer> answers = new List<QuestionAnswer>() { 
                    new QuestionAnswer() { Question = "Q1", Answer = "a"},
                    new QuestionAnswer() { Question = "Q1", Answer = "b"},
                    new QuestionAnswer() { Question = "Q2", Answer = "c"},
                    new QuestionAnswer() { Question = "Q2", Answer = "d"},
                    new QuestionAnswer() { Question = "Q2", Answer = "e"},
                };
                DataTable dt = new DataTable();
                List<string> uniqueQuestions = answers.Select(x => x.Question).Distinct().ToList();
                foreach (string question in uniqueQuestions)
                {
                    dt.Columns.Add(question, typeof(string));
                }
                var groups = answers.GroupBy(x => x.Answer).ToList();
                foreach (var group in groups)
                {
                    DataRow newRow = dt.Rows.Add();
                    foreach (QuestionAnswer qA in group)
                    {
                        newRow[qA.Question] = qA.Answer;
                    }
                }
            }
        }
        public class QuestionAnswer
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }
    }
