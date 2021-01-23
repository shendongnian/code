    [DataContract]
    public class KioskSettings
    {
        [DataMember(Order = 1)]
        public string ID { get; set; }
        [DataMember(Order = 2)]
        public int HeartBeatInterval { get; set; }
        [DataMember(Order = 3)]
        public string ServerURL { get; set; }
        [DataMember(Order = 4)]
        public string EncryptionKey { get; set; }
    }
