    public sealed class Document
    {
        public int Id { get; set; }
        // ...
        public ICollection<DocumentField> Fields { get; set; }
    }
    public sealed class DocumentField
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string StringValue { get; set; }
        public float? FloatValue { get; set; }
        // more typed vales here
    }
