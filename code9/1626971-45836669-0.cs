    [DataContract]
    public class Car
    {
        [DataMember]
        public string model;
        [DataMember]
        public CarConditionEnum condition;
    }
    
    [DataContract(Name = "CarCondition")]
    public enum CarConditionEnum
    {
        [EnumMember]
        New,
        [EnumMember]
        Used,
        [EnumMember]
        Rental,
        Broken,
        Stolen
    }
