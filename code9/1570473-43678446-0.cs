    public class Foo
    {
        public string A { get; set; }
        public int B { get; set; }
        public C Value { get; set; } // add same to Bar class
        public class C
        {
            public string D { get; set; }
        }
    }
