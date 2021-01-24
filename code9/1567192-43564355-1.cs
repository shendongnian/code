    public class State
    {
        [JsonProperty("on")]
        public bool IsOn { get; set; }
        
        [JsonProperty("bri")]
        public int Brightness { get; set; }
        [JsonProperty("hue")]
        public int Hue { get; set; }
        [JsonProperty("sat")]
        public int Saturation { get; set; }
        [JsonProperty("effect")]
        public string Effect { get; set; } // Just making it a string for now
        [JsonProperty("xy")]
        public double[] XY { get; set; }
        [JsonProperty("ct")]
        public int CT { get; set; }
        [JsonProperty("alert")]
        public string Alert { get; set; } // Just making another string for now
        [JsonProperty("colormode")]
        public string ColorMode { get; set; } // Hey, it's another string for now
        [JsonProperty("reachable")]
        public bool Reachable { get; set; }
    }
