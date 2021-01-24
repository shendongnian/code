    public class KeuringRegel
    {
        public string Projekt { get; set; }
        public string Ruimte { get; set; }
        public Apparaat Apparaat { get; set; }
        [JsonProperty(PropertyName = "Apparaat naam")]
        public string Apparaatnaam { get; set; }
        public string Status { get; set; }
        [JsonExtensionData()]
        public TestNames testNames { get; set; }
    }
    
    public class TestNames : Dictionary<string, object>
    {
        public new void Add(string key, object value)
        {
            if (key.StartsWith("testname", StringComparison.OrdinalIgnoreCase))
            {
                base.Add(key, value);
            }
        }
    }
