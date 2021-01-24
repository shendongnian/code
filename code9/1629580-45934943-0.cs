    [Serializable]
    public class Priority {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "sortindex")]
        public int SortIndex { get; set; }
    }
