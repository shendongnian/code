    [DataContract]
    [KnownType(typeof(QuestionTrueOrFalse))]
    [KnownType(typeof(QuestionMultipleChoice))]
    public class ReturnedObjectList<Question>
    {
        [DataMember]
        public List<Question> ListItems = new List<Question>();
        [DataMember]
        public string Status { get; set; } = "";
        public string Message { get; set; } = "";
    }
   
