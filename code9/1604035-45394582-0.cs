    public class ChangeType
    {
        [JsonProperty("#text")]
        [XmlText]
        public string Text { get; set; }
    }
    public class GenericChangeType<T> : ChangeType
    {
    }
