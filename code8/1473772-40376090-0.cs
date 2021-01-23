    [DataContract(Namespace="")]
    public class XMLFile
    {
        [DataMember]
        public List<SalesOrder> SalesOrders { get; set; }
    }
    
    [DataContract(Namespace="")]
    public class SalesOrder
    {
        [DataMember(Order = 1)]
        public string OrderNumber { get; set; }
    }
