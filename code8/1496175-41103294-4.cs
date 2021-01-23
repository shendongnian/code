    [XmlRoot(Namespace = "http://TestBizTalkMap.Student")]
    public class StudentInfo
    {
		[XmlElement(Namespace = "")]
        public Student Student { get; set; }
        [XmlElement(Namespace = "http://TestBizTalkMap.Address")]
        public Address Address { get; set; }
    }
    public class Student
    {
        public string EnrollNo { get; set; }
        public string Name { get; set; }
        public string BTSReceivedOn { get; set; }
    }
    public class Address
    {    
        [XmlElement(Namespace = "")]
        public string City { get; set; }        
        [XmlElement(Namespace = "")]
        public string State { get; set; }
    }
