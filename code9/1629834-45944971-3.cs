    public class QuestionTxt
    {
        [JsonProperty()]  // notice that property is internal
        internal List<Answer> answers { get; set; }
        public string name { get; set; }
        public Question()
        {
            answers = new List<Answer>();
        }
    }
