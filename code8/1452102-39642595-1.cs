    [DataContract(Namespace="")]
        class A
        {
            [DataMember(Name = "B")]
            private B instanceB;
            [DataMember(Name = "integerValue")]
            private int integerValue;
    
            public A(B instanceB, int integerValue)
            {
                this.instanceB = instanceB;
                this.integerValue = integerValue;
            }
        }
    
        [DataContract(Namespace = "")]
        class B
        {
            [DataMember(Name = "cInstanceList")]
            private List<C> cInstanceList;
    
            [DataMember(Name = "stringValue")]
            private string stringValue;
    
            public B(List<C> cInstanceList, string stringValue)
            {
                this.cInstanceList = cInstanceList;
                this.stringValue = stringValue;
            }
        }
    
        [DataContract(Namespace = "")]
        class C
        {
        }
