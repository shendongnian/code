    [OperationContract]
    ResponseObj Test(RequestMessage request);
    
    
    [DataContract]
    public class RequestMessage
    {
       [DataMember(IsRequired = true)]
       public string TestString{ get; set; }
    }
