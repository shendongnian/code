    [DataContract]
    [KnownType(typeof(QuestionTrueOrFalse))]
    [KnownType(typeof(QuestionMultipleChoice))]
    public class ReturnedObjectList<Question>
    {
        public List<Question> ListItems = new List<Question>();
        public string Status = "", Message = "";
    }
