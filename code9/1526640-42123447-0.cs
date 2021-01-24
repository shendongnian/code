    [KnownType(typeof(A))]
    [DataContractAttribute]
    class A
    {
        public A(object a, object b, object c)
        {
            d = a;
            e = b;
            f = c;
        }
        [DataMember]
        public object d;
        [DataMember]
        public object e;
        [DataMember]
        public object f;
    }
