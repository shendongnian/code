    public class CoordPoint
    {
        public int row { get; set; }
        public int col { get; set; }
    }
    public class CoordPointsArray
    {
        [JsonProperty(Order = 1)]
        public string Name { get; set; }
        [JsonProperty(Order = 2)]
        public List<CoordPoint> Coordinates { get; set; }
    }
