    public class VRates
    {
        public Dictionary<string, VRate> rates { get; set; }
    }
    public class VRate
    {
        public string country { get; set; }
        public float standard_rate { get; set; }
        public float reduced_rate { get; set; }
        public float reduced_rate_alt { get; set; }
        public bool super_reduced_rate { get; set; }
        public float parking_rate { get; set; }
    }
