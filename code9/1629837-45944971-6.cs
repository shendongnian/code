    public class QuestionTxt
    {
        [JsonProperty()]
        internal List<Answer> answers { get; set; }  // notice internal!
        public string name { get; set; }
        public Question()
        {
            answers = new List<Answer>();
        }
    }
