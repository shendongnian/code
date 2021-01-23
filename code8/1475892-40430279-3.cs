    public class Settings
    {
        public string PLCIP;
        [JsonConverter(typeof(IPByteArrayConverter))]
        public byte[] RightTesterIP;
        [JsonConverter(typeof(IPByteArrayConverter))]
        public byte[] LeftTesterIP;
    }
