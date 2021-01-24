    public class DeviceStatus
    {
        public int totalDevices { get; set; }
        public int startIndex { get; set; }
        public int utcTimestamp { get; set; }
        [JsonProperty("list")]
        public List<Device> device { get; set; }
    }
