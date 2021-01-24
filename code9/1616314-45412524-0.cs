    class RootObject
    {
        public List<SeriesItem> series { get; set; } = new List<SeriesItem>();
    }
 
    class SeriesItem
    {
        public string type { get; set; }
        public string name { get; set; }
        public bool? showInLegend  { get; set; }
        public List<object> data  { get; set; } = new List<object>();
    }
    class OtherData
    {
        public int y { get; set; }
        public int mydata { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public Marker marker { get; set; }
    }
    class Marker
    {
        public string symbol { get; set; }
    }
