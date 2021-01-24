    using Newtonsoft.Json;
    public class RootObject
    {
        [JsonProperty("images")]
        public Image[] Images { get; set; }
        [JsonProperty("images_processed")]
        public long ImagesProcessed { get; set; }
    }
    public class Image
    {
        [JsonProperty("faces")]
        public Face[] Faces { get; set; }
        [JsonProperty("resolved_url")]
        public string ResolvedUrl { get; set; }
        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }
    }
    public class Face
    {
        [JsonProperty("age")]
        public Age Age { get; set; }
        [JsonProperty("face_location")]
        public FaceLocation FaceLocation { get; set; }
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("identity")]
        public Identity Identity { get; set; }
    }
    public class Identity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
    }
    public class Gender
    {
        [JsonProperty("gender")]
        public string PurpleGender { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
    }
    public class FaceLocation
    {
        [JsonProperty("height")]
        public long Height { get; set; }
        [JsonProperty("left")]
        public long Left { get; set; }
        [JsonProperty("top")]
        public long Top { get; set; }
        [JsonProperty("width")]
        public long Width { get; set; }
    }
    public class Age
    {
        [JsonProperty("max")]
        public long Max { get; set; }
        [JsonProperty("min")]
        public long Min { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
    }
