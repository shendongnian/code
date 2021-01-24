    public class Artist
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
    }
    public class Image
    {
        [JsonProperty("#text")]
        public string text { get; set; }
        public string size { get; set; }
    }
    public class Attr
    {
        public string rank { get; set; }
    }
    public class Album
    {
        public string name { get; set; }
        public string playcount { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public Artist artist { get; set; }
        public List<Image> image { get; set; }
        [JsonProperty("@attr")]
        public Attr attr { get; set; }
    }
    public class Attr2
    {
        public string user { get; set; }
        public string page { get; set; }
        public string perPage { get; set; }
        public string totalPages { get; set; }
        public string total { get; set; }
    }
    public class Topalbums
    {
        public List<Album> album { get; set; }
        [JsonProperty("@attr")]
        public Attr2 attr { get; set; }
    }
    public class RootObject
    {
        public Topalbums topalbums { get; set; }
    }
