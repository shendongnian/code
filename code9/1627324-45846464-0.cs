    var result = JsonConvert.DeserializeObject<SOTest.Result>(json);
----
    public class SOTest
    {
        public class PropertyAddress
        {
            public string Address1 { get; set; }
            public object Address2 { get; set; }
            public string Zip { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string County { get; set; }
        }
        public class Summary
        {
            public object BorrowerName { get; set; }
            public object ProductCode { get; set; }
            public string Status { get; set; }
        }
        public class Value
        {
            public string RecordNumber { get; set; }
            public string RecordType { get; set; }
            public PropertyAddress PropertyAddress { get; set; }
            public Summary Summary { get; set; }
        }
        public class Result
        {
            [JsonProperty("@odata.context")]
            public string Context { get; set; }
            public List<Value> Value { get; set; }
        }
    }
