    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        AbstractResult GetAbstractData(int id);
    }
    [DataContract]
    [KnownType(typeof(ConcreteResult1))]
    [KnownType(typeof(ConcreteResult2))]
    public abstract class AbstractResult
    {
        [DataMember]
        public int ID { get; set; }
    }
    [DataContract]
    public class ConcreteResult1 : AbstractResult
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class ConcreteResult2 : AbstractResult
    {
        [DataMember]
        public int Number { get; set; }
    }
