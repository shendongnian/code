    [ServiceContract]
    public interface IWcfClient
    {
        [XmlSerializerFormat]
        [OperationContract(IsOneWay = true)]
        void SendUpdates(UpdateRequest request);
    }
    
    [MessageContract(IsWrapped = false)]
    public class UpdateRequest
    {
        [MessageBodyMember(Name="UpdateEntry")]
        public UpdateEntry[] UpdateEntries { get; set; }
    }
    
    [Serializable]
    [XmlType(Namespace = "myNamespace")]
    public class UpdateEntry
    {
        [XmlElement(ElementName = "UpdateEntry", Order = 0)]
        public Device[] DeviceInfo { get; set; }
    
        [XmlElement(ElementName = "UpdateType", Order = 1)]
        public byte UpdateType { get; set; }
    }
    
    [Serializable]
    [XmlType(Namespace = "myNamespace")]
    public class Device
    {
        [XmlElement(ElementName = "DeviceId", Order = 0)]
        public string DeviceId { get; set; }
    
        [XmlElement(ElementName = "LastSeen", Order = 1)]
        public DateTime LastSeen { get; set; }
    }
