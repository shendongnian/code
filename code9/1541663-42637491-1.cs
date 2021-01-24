    interface I
    {
        int Value { get; set; }
    }
    
    class Foo : I
    {
        public int Value { get; set; }
    }
    
    class C : Foo
    {
        public int Value { get; set; }
    }
