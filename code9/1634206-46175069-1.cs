    [JsonObject(MemberSerialization.OptOut)]
    public class NewQuestionItem : QuestionItem
    {
        private DateTime _firstAccess;
        [JsonConstructor]
        public NewQuestionItem(int Id, int Variant, DateTime FirstAccess) : base(Id, Variant)
        {
            this.FirstAccess = FirstAccess;
        }
        public DateTime FirstAccess { get; }
    }
