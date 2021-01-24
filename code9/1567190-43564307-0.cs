    public class State
    {
        public bool on { get; set; }
        public int bri { get; set; }
        public int hue { get; set; }
        public int sat { get; set; }
        public string effect { get; set; }
        public List<double> xy { get; set; }
        public int ct { get; set; }
        public string alert { get; set; }
        public string colormode { get; set; }
        public bool reachable { get; set; }
    }
    public class RootObject
    {
        public State state { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string modelid { get; set; }
        public string manufacturername { get; set; }
        public string uniqueid { get; set; }
        public string swversion { get; set; }
    }
