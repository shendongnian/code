    public enum LocaleEnum
    {
        En = 1,
        Jp = 2
    }
    public class LocalDoc
    {
        [BsonId]
        public ObjectId mongoId { get; set; }
        public string host { get; set; }
        public Dictionary<LocaleEnum, string> locale { get; set; }
    }
