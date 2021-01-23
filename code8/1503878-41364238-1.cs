    [XmlSerializerFormat, ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        MyData GetData();
    }
    [DataContract]
    public class MyData
    {
        [XmlAttribute, DataMember]
        public int Value1 { get; set; }
        // Explicit method to control serialization of Value1 property
        public bool ShouldSerializeValue1()
        {
            // do not serialize this value if it's 0
            return Value1 != 0;
        }
        // Use default value of 0 to prevent serializing zeros
        [XmlAttribute, DataMember, DefaultValue(0)]
        public int Value2 { get; set; }
    }
