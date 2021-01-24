    internal class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    internal class Bounds
    {
        public Bounds()
        {
            MinLat = double.MaxValue;
            MaxLat = double.MinValue;
            MinLon = double.MaxValue;
            MaxLon = double.MinValue;
        }
        public double MinLat { get; set; }
        public double MaxLat { get; set; }
        public double MinLon { get; set; }
        public double MaxLon { get; set; }
    }
