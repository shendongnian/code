    public class KeuringRegel
    {
        public string Projekt { get; set; }
        public string Ruimte { get; set; }
        public Apparaat Apparaat { get; set; }
        [JsonProperty(PropertyName = "Apparaat naam")]
        public string Apparaatnaam { get; set; }
        public string Status { get; set; }
        [JsonExtensionData()]
        public Dictionary<string, object> testNames { get; set; }
    }
