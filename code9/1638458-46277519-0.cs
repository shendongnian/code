    public class TagList
    {
        [JsonProperty("tags")]
        List<string> Tags { get; set; }
        public TagList(params string[] tags)
        {
            Tags = tags.ToList();
        }
    }
