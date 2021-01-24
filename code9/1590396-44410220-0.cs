     [DataContract]
    public class GetExchange_Reason_ListResult
    {
        [DataMember]
        public Exchange_Reason[] Exchange_Reasons { get; set; }
    }
    
    public class Exchange_Reason
    {
        public string Exchange_Reason_ID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
