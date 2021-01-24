    public class AnswerOption
    {
        [JsonProperty("parentQuestion")]
        public string ParentQuestion { get; set; }
        [JsonProperty("parentAnswer")]
        public object ParentAnswer { get; set; }
        [JsonProperty("answerOption")]
        public object AnswerOption { get; set; }
    }
    public class Question
    {
        [JsonProperty("questionId")]
        public int QuestionId { get; set; }
        [JsonProperty("questionName")]
        public string QuestionName { get; set; }
        [JsonProperty("questionType")]
        public string QuestionType { get; set; }
        [JsonProperty("questionSequenceNumber")]
        public int QuestionSequenceNumber { get; set; }
        [JsonProperty("pageNo")]
        public int PageNo { get; set; }
        [JsonProperty("highlightedText")]
        public string HighlightedText { get; set; }
        [JsonProperty("isDynamicText")]
        public string IsDynamicText { get; set; }
        [JsonProperty("answerOptions")]
        public IList<AnswerOption> AnswerOptions { get; set; }
    }
    public class DataObj
    {
        [JsonProperty("surveyId")]
        public int SurveyId { get; set; }
        [JsonProperty("questions")]
        public IList<Question> Questions { get; set; }
    }
    public class Example
    {
        [JsonProperty("dataObj")]
        public DataObj DataObj { get; set; }
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
