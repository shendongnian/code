    [DataContract(Namespace = "")]
    public class CardCommonDefinition
    {
        public CardCommonDefinition()
        {
            this.Icon = new CardFieldDefinitionEntity();
        }
        [DataMember]
        public string PassTypeIdentifier {get; set;}
        [DataMember]
        public CardFieldDefinitionEntity Icon {get; set;}
    }
    
    [DataContract(Namespace = "")]
    public class Coupon : CardCommonDefinition
    {
        public Coupon : base()
        { }
        [DataMember]
        public string Description {get; set;}
        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }
    }
