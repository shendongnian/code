        public class Person
        {
            [DataMember]
            public Guid Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            [IgnoreDataMember]
            public string Address { get; set; }
            [IgnoreDataMember]
            public int PinCode { get; set; }
            [DataMember]
            public string Phone { get; set; }
        }
