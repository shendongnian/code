    namespace V2
    {
        [DataContract(Name = "Member", Namespace = "Question45008433", IsReference = true)]
        public class Member
        {
            [DataMember]
            public string Name { get; set; }
        }
        [DataContract(Name = "Root", Namespace = "Question45008433")]
        public class RootObject
        {
            [DataMember(Order = 2)]
            public List<Member> Members { get; set; }
        }
    }
