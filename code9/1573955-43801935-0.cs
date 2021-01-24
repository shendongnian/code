    public class SensorResult
    {
        public float Humidity { get; set; }
        public float Temp { get; set; }
        public int Light { get; set; }
        public bool Button { get; set; }
    }
    Dictionary<int, SensorResult> items = new Dictionary<int, SensorResult>();
