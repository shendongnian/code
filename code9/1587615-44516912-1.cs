    public class A  
    { 
        public string Id {get;set;}
        public List<B> Children {get;set;}
    }
    [BsonNoId] // this solves the problem
    public class B
    {
        public string Id {get;set;}
        public string Foo {get;set;}
        public double Bar {get;set;}
    }
