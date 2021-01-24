    public class Data
    {
        public string Day { get; set; }
        public string Depth { get; set; }
        public string IRIS_ID { get; set; }
        public string Latitude { get; set; }
        public override string ToString()
        {
            return $"{Day}, {Depth}, {IRIS_ID}, {Latitude}";
        }
    }
