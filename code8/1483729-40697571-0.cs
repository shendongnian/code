    var result = JsonConvert.DeserializeObject<List<List<SomeObject>>>(json);
    public class SomeObject
    {
        public string trackingNo { get; set; }
        public long eventTime { get; set; }
        public string eventCode { get; set; }
        public string activity { get; set; }
        public string location { get; set; }
        public string referenceTrackingNo { get; set; }
    }
