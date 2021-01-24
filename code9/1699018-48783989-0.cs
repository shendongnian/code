    public class Song
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("track")]
        public string Track { get; set; }
        [JsonProperty("artist")]
        public string Artist { get; set; }
    }
    public class PlayListItem
    {
        [JsonProperty("song")]
        public Song Song { get; set; }
        [JsonProperty("playedtime")]
        public DateTime PlayedTime { get; set; }
    }
