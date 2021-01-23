    namespace WcfService1
    {
        [ServiceContract]
        public interface IService1
        {
    
            [OperationContract]
            List<US_States> GetAllStates();
    
        }
    
    
        [DataContract]
        public class US_States
        {
            [DataMember]
            public int StateId { get; set; }
    
            [DataMember]
            public string StateName { get; set; }
        }
    }
