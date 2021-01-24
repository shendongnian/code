    [DataContract]
    public class ChannelData
    {
        [DataMember, XmlAttribute("name")]
        public string Name { get; set; }
        [DataMember, XmlAttribute("txTime")]
        public string txTimeForSerialization { get; set; }
    }
