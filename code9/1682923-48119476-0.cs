    public class Example
    {
        [JsonProperty(PropertyName = "favoriteColor")]
        public string favoriteColor { 
          get { return favoriteColor; } ; 
          set
          {
            favoriteColor = value;
            oldFavoriteColor = value;
          }
        }
        public string oldFavoriteColor { get; set; }
    }
