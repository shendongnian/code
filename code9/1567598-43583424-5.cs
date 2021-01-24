    [DataContract]
    public class Question
    {
        [DataMember]
        String QuestionsID { get; set; } = "";
    }
    [DataContract]
    public class QuestionTrueOrFalse : Question
    {
        [DataMember]
        public string Answer { get; set; } = "";
    }
    [DataContract]
    public class QuestionMultipleChoice : Question
    {
        [DataMember]
        public List<MultipleChoiceOption> obj { get; set; }
    }
    [DataContract]
    public class MultipleChoiceOption
    {
        [DataMember]
        public int OptionMultipleChoiceID { get; set; } = 0;
        [DataMember]
        public string OptionsTextAr { get; set; } = "";
        [DataMember]
        public string Answer { get; set; } = "";
    }
