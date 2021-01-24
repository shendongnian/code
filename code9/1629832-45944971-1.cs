    public class QuestionTxt
    {
        [JsonProperty()]  // notice attribute
        public List<Answer> answers { get; set; }
        public string name { get; set; }
        public Question()
        {
            answers = new List<Answer>();
        }
    }
