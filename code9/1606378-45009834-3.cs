    namespace V3
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
            [DataMember(EmitDefaultValue = false, Order = 1)]
            Member MainMember
            {
                get
                {
                    return null;
                }
                set
                {
                    // Do nothing
                }
            }
            [DataMember(Order = 2)]
            public List<Member> Members { get; set; }
        }
    }
