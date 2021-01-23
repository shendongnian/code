    [ServiceContract]
    [XmlSerializerFormat]
    public interface IService1
    {
        [OperationContract]
        List<Nullable<DateTime>> NullTest();
    }
