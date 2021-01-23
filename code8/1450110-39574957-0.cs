    public class Person
    {
        public int PersonId {get;set;}
        //...
        public int PhoneCarrierId { get; set; }
        public virtual PhoneCarrier PhoneCarrier { get; set; }
    }
    
    public class PhoneCarrier 
    {
        public int PhoneCarrierId {get;set;}
        //...
    }
