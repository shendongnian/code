    public sealed class ConfigurationCount
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonIgnore]
        public bool IsValid => Enum.IsDefined(typeof(MyEnums.Game), game);
        [JsonProperty("game")]
        private int game { get; set; }
        [JsonIgnore]
        public MyEnums.Game Game
        {
            get
            {
                if (!IsValid) throw new InvalidOperationException("Object is invalid");
                return (MyEnums.Game) game;
            }
            set { game = (int) value; } 
        }
    }
