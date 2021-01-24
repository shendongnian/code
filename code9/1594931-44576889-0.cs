    public class Question
    {
        [JsonProperty("Category")]
        public string Category { get; set; }
        [JsonProperty("Question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public string Answer { get; set; }
    }
    public class QuestionsDatePlace
    {
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("Place")]
        public string Place { get; set; }
        [JsonProperty("Questions")]
        public IList<Question> Questions { get; set; }
    }
