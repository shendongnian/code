    public class TrackModel
    {
        [JsonProperty(PropertyName = "headers")]
        public Headers Headers { get; set; }
        [JsonProperty(PropertyName = "results")]
        public Result[] Results { get; set; }
    }
    public class Headers
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "error_message")]
        public string Errormessage { get; set; }
        [JsonProperty(PropertyName = "warnings")]
        public string Warnings { get; set; }
        [JsonProperty(PropertyName = "results_count")]
        public string ResultsCount { get; set; }
    }
    public class Result
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        [JsonProperty(PropertyName = "artist_id")]
        public string ArtistId { get; set; }
        [JsonProperty(PropertyName = "artist_name")]
        public string ArtistName { get; set; }
        [JsonProperty(PropertyName = "artist_idstr")]
        public string ArtistIdstr { get; set; }
        [JsonProperty(PropertyName = "album_name")]
        public string AlbumName { get; set; }
        [JsonProperty(PropertyName = "album_id")]
        public string AlbumId { get; set; }
        [JsonProperty(PropertyName = "license_ccurl")]
        public string LicenseCcurl { get; set; }
        public int Position { get; set; }
        public string Releasedate { get; set; }
        [JsonProperty(PropertyName = "album_image")]
        public string AlbumImage { get; set; }
        public string Audio { get; set; }
        public string Audiodownload { get; set; }
        public string Prourl { get; set; }
        public string Shorturl { get; set; }
        public string Shareurl { get; set; }
        public string Image { get; set; }
    }
