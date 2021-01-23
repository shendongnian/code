    [DataContract(Namespace = "libTypes.salesApp")]
    public class PxePriceListEod
    {
        [DataMember]
        public DateOfValidity DateOfValidity { get; set; }
    }
    // DateOfValidity 
    [DataContract(Namespace = "libTypes")]
    public class DateOfValidity
    {
        [DataMember(Name = ".")]
        public DateTime DateTime { get; set; }
    }
