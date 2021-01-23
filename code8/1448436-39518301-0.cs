       private void Test()
        {
            JArray ja = JArray.Parse(str);
            var ja1 = JArray.Parse(ja[0].ToString());
            var ja2 = JArray.Parse(ja[1].ToString());
            List<QuestionNew> s1 = JsonConvert.DeserializeObject<List<QuestionNew>>(ja1.ToString());
            List<AnswerNew> s2 = JsonConvert.DeserializeObject<List<AnswerNew>>(ja2.ToString());
            QuestionAndAnswerNewMarge q = new QuestionAndAnswerNewMarge();
            q.QuestionNew = s1;
            q.AnswerNew = s2;
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
