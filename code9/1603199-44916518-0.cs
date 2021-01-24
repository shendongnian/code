    //Simple POCO with 11 String properties, 7 DateTime properties
    [DataContractAttribute()]
    public class Employee
    {
        [DataMember()]
        public string FirstName { set; get; }
        [DataMember()]
        public string LastName { set; get; }
        //...omitted for clarity
        [DataMember()]
        public DateTime Date03 { set; get; }
        [DataMember()]
        public DateTime Date04 { set; get; }
    }
