    public class RootObject
    {
        [JsonPropertyExtensions(EmptyArrayHandling = EmptyArrayHandling.Ignore)]
        public string[] PostalAddress { get; set; }
    }
