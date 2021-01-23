        public void Convert()
        {
            var questionsAnswers = new QuestionsAnswers()
            {
                Answers = new List<Answ>(),
                Questions = new List<Qst>()
            };
            string str = "[[{\"QID\":1,\"Question\":\"Question\",\"IsMultipel\":0},{\"QID\":2,\"Question\":\"Question\",\"IsMultipel\":1}],[{\"QID\":1,\"A_ID\":1,\"Answer\":\"Answer\"},{\"QID\":1,\"A_ID\":2,\"Answer\":\"Answer\"},{\"QID\":1,\"A_ID\":3,\"Answer\":\"Answer\"},{\"QID\":1,\"A_ID\":3,\"Answer\":\"Answer\"}]]";
            var d = JsonConvert.DeserializeObject<dynamic[][]>(str);
            foreach (var objects in d)
            {
                if (objects.All(a => a["A_ID"] == null))
                {
                    questionsAnswers.Questions.AddRange(objects.Select(a => new Qst()
                    {
                        IsMultipel = a[nameof(Qst.IsMultipel)],
                        Question = a[nameof(Qst.Question)],
                        QID = a[nameof(Qst.QID)]
                    }));
                }
                else
                {
                    questionsAnswers.Answers.AddRange(objects.Select(a => new Answ()
                    {
                        A_ID = a[nameof(Answ.A_ID)],
                        Answer = a[nameof(Answ.Answer)],
                        QID = a[nameof(Answ.QID)]
                    }));
                }
            }
        }
        public class QuestionsAnswers
        {
            public List<Qst> Questions { get; set; }
            public List<Answ> Answers { get; set; }
        }
        public class Qst
        {
            public int QID { get; set; }
            public string Question { get; set; }
            public bool IsMultipel { get; set; }
        }
        public class Answ
        {
            public int QID { get; set; }
            public int A_ID { get; set; }
            public string Answer { get; set; }
        }
