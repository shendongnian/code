    public class Vehicle
    {
        [JsonProperty(PropertyName = "pre")]
        public string Prefix { get; set; }
        [JsonIgnore]
        public Position Position { get; set; }
        [JsonProperty(PropertyName = "posx")]
        private string Y
        {
            get { return Position != null ? Position.Y : null; }
            set
            {
                if (Position == null) { Position = new Position(); }
                Position.Y = value;
            }
        }
        [JsonProperty(PropertyName = "posy")]
        private string X
        {
            get { return Position != null ? Position.X : null; }
            set
            {
                if (Position == null) { Position = new Position(); }
                Position.X = value;
            }
        }
    }
