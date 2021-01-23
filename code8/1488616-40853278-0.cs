    public class Location
    {
        [JsonProperty("City")]
        public string City {get; set;}
        [JsonProperty("Value")]
        public double Population {get; set;}
        [JsonIgnore]
        public double Latitude {get; set;}
        [JsonIgnore]
        public double Longitude {get; set;}
        public double[] Location 
        {
            get { return new double[] { Latitude, Longitude }; }
        }
    }
