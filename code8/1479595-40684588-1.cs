        [DataContract(Namespace = "")]
        public abstract class SoapFaultExceptionBase
        {
            [DataMember(IsRequired = true)]
            public string faultcode { get; set; }
    
            [DataMember(IsRequired = true)]
            public string faultstring { get; set; }
        }
    
        [DataContract(Namespace = "http://example.com/foo/")]
        public class SoapFaultException : SoapFaultExceptionBase
        {
        }
