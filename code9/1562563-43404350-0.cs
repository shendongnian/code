        public class RootObject
        {
            public SplunkDataModel Summary { get; set; }
        }
    Then:
        var deserialized = JsonConvert.DeserializeObject<RootObject>(contents).Summary;
