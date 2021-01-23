    public class DeviceInfo
    {
        [JsonProperty("id")]
        public int DeviceID { get; set; }
        [JsonProperty("id_endpoint")]
        public int EndpointID { get; set; }
        [JsonProperty("name")]
        public string DeviceName { get; set; }
        [JsonProperty("minthreshold")]
        public double MinThreshold { get; set; }
        [JsonProperty("maxthreshold")]
        public double MaxThreshold { get; set; }
        [JsonProperty("value")]
        public double CurrentValue { get; set; }
        [JsonProperty("time")]
        public DateTime ValueTime { get; set; }
        [JsonProperty("address")]
        public string EndpointAddress { get; set; }
        [JsonProperty("id_user")]
        public int IDUser { get; set; }
    }
