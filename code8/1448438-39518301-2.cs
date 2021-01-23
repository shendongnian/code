        private void Test()
        {
           QuestionAndAnswerNewMarge q = new QuestionAndAnswerNewMarge();
            JArray ja = JArray.Parse(json);
            var ja1 = JArray.Parse(ja[0].ToString());
            var ja2 = JArray.Parse(ja[1].ToString()); 
            q.QuestionNew = JsonConvert.DeserializeObject<List<QuestionNew>>(ja1.ToString());
            q.AnswerNew = JsonConvert.DeserializeObject<List<AnswerNew>>(ja2.ToString());
        }
        public class QuestionAndAnswerNewMarge
        {
            public List<QuestionNew> QuestionNew { get; set; }
            public List<AnswerNew> AnswerNew { get; set; }
        }
        public class QuestionNew
        {
            public int QID { get; set; }
            public string Question { get; set; }
            public int IsMultiple { get; set; }
        }
        public class AnswerNew
        {
            public string QID { get; set; }
            public string A_ID { get; set; }
            public string Answer { get; set; }
        }
