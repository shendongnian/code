    public class Wiki
    {
        ...
        [JsonConverter(typeof(IgnoreEmptyItemsConverter<Tag>))]
        public IEnumerable<Tag> Tags { get; set; }
    }
