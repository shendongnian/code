    public class Videogame
    {
        public string name{ get; set; }
    
        [JsonProperty("release_date")]
        public DateTime old 
        { 
              set { ReleaseDate = value; }
        }
    
        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
