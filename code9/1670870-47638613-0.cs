    public class RequestData
    {
        public string id { get; set; }
        public List<points> points { get; set; }  // I use list, could be an array
    }
    public class points
    {
        public DateTime timestamp { get; set; }
        public float value { get; set; }
    }
