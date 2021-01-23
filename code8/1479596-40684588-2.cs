        [DataContract(Namespace = "")]
        public class SoapFaultException
        {
            [DataMember(IsRequired = true)]
            public string faultcode { get; set; }
            [DataMember(IsRequired = true)]
            public string faultstring { get; set; }
        }
    And then do:
        var serializer = new DataContractSerializer(typeof(SoapFaultException), "SoapFaultException", "http://example.com/foo/");
        var e = (SoapFaultException)serializer.ReadObject(xml.CreateReader());
