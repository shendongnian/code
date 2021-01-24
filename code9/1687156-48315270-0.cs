    public class A
        {
            public int MyPropertyA1 { get; set; }
            public string MyPropertyA2 { get; set; }
    
            public ICollection<B> MyPropertyA3 { get; set; }
        }
    
        public class B
        {
            public int MyPropertyB1 { get; set; }
            public string MyPropertyB2 { get; set; }
        }
