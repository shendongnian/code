    public class Requirments
    {
        public int FileID { get; set; }
        public string EventMessageUId { get; set; }
        public string ProjectId { get; set; }
        [JsonConverter(typeof(StringConverterDecorator), typeof(SingleOrArrayConverter))]
        public List<Message> Message { get; set; }
        public string error { get; set; }
    }
