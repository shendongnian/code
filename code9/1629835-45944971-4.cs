    public class QuestionTxt
    {
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
        [JsonProperty("name")]
        public string Name{ get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
    public class Answer
    {
        [JsonProperty("answer")]
        public string Value { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
   
