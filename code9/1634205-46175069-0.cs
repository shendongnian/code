    [JsonObject(MemberSerialization.OptOut)]
    public class QuestionItem 
    {
        [JsonConstructor]
        public QuestionItem(int Id, int Variant)
        {
            this.Id = Id;
            this.Variant = Variant;
        }
        public int Id { get; }
        public int Variant { get; }
        public string Name { get; set; }
    }
