    [XmlRoot(Namespace = "http://TestBizTalkMap.Student")]
    public class StudentInfo
    {
        public Student Student { get; set; }        
        public Address Address { get; set; }
    }
    public class Student
    {
        public string EnrollNo { get; set; }
        public string Name { get; set; }
        public string BTSReceivedOn { get; set; }
    }
	[XmlType(Namespace="http://TestBizTalkMap.Address")]
    public class Address
    {    
        public string City { get; set; }        
        public string State { get; set; }
    }
