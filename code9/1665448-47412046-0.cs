    public class ChainHeightDTO
    {
        [JsonProperty("height")]
        private uint[] _height 
        {
            get { return new uint[] { Height % 256, Height / 256 }; }
            set { Height = value[0] + value[1] * 256; }
        }
        [JsonIgnore]
        public long Height { get; set; }
    }
