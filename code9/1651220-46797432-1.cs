    [DataContract]
        class Foo
        {
            [DataMember] private string _boo;
    
            public Foo(string boo) => _boo = boo;
    
            public string Boo => _boo;
        }
