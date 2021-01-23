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
                DataTable dt = new DataTable();
                dt.Columns.Add("Q_id", typeof(int));
                dt.Columns.Add("Question", typeof(string));
                dt.Columns.Add("Question_type", typeof(string));
                dt.Columns.Add("MatchA", typeof(string));
                dt.Columns.Add("MatchB", typeof(string));
                dt.Columns.Add("Std", typeof(int));
                dt.Columns.Add("sub", typeof(string));
                dt.Rows.Add(new object[] { 1, "Where is Lion live?", "Ques_Ans", null, null, 1, "eng"});
                dt.Rows.Add(new object[] { 2, "What is sun ?", "Ques_Ans", null, null, 1, "eng"});
                dt.Rows.Add(new object[] { 3, null, "Matching", "Lion", "Den", 1, "eng"});
                dt.Rows.Add(new object[] { 4, null, "Matching", "Hen", "Coop", 1, "eng"});
                dt.Rows.Add(new object[] { 5, null, "Matching", "Rabbit", "Burrow", 1, "eng"});
                dt.Rows.Add(new object[] { 6, null, "Matching", "Earth", "Planet", 2, "eng"});
                List<DataRow> questions = dt.AsEnumerable().Where(x => x.Field<string>("Question_type") == "Ques_Ans").ToList();
                List<DataRow> answers = dt.AsEnumerable().Where(x => x.Field<string>("Question_type") == "Matching").ToList();
                Random rand = new Random();
                foreach(DataRow question in questions)
                {
                    List<DataRow> questionAnswers = answers.Where(x => x.Field<int>("Std") == question.Field<int>("Q_id")).ToList();
                    //create random list of Match B
                    var randB = questionAnswers.Select(x => new { B = x.Field<string>("MatchB"), rand = rand.Next() }).OrderBy(x => x.rand).ToList();
                    Console.WriteLine("Question {0}", question.Field<string>("Question"));
                    for(int i = 0; i < questionAnswers.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}     {2}", i + 1, questionAnswers[i].Field<string>("MatchA"), randB[i].B);
                    }
                }
                Console.ReadLine();
                                    
            }
        }
    }
