     [DataContract]
        public class MyDataClass
        {
            [DataMember]
            public string Name { get; set; }
    
            [DataMember]
            public int Id { get; set; }
    
            [DataMember]
            public DateTime DateOfBirth { get; set; }   
        }
