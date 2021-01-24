    public class RootObject
    {
        public string name { get; set; }
        public NestedData data { get; set; }
        public float[] Values { get; set; }
    }
    public class NestedData
    {
        public string foo { get; set; }
        public string bar { get; set; }
    }
