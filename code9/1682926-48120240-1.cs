    public class Example
    {
        [JsonIgnore]
        public string favoriteColor { get; set; }
        [JsonProperty(PropertyName = "favoriteColor")]
        public string oldFavoriteColor { get; set; }
    }
