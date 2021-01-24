    [DataContract]
    public class Employee {
       [DataMember]
        public string EmpId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string OrganizationName { get; set; }
    }
    [DataContract]
    public class Celebrity {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Language { get; set; }
    }
    
