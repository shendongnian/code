    [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Customer/{customerID}/verification")]
        string PutCustomerVerificationData(string customerID, CustomerVerification customerVerification);
    }
    
    [DataContract]
    public class CustomerVerification
    {
        [DataMember]
        public string PasswordHash { get; set; }
    
        [DataMember]
        public string PasswordSalt { get; set; }
    }
