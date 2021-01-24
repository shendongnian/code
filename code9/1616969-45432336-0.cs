    public class Foo 
    {
        public virtual Bar Bar { get; set; }
    }
    public class Bar 
    {
        public virtual List<Baz> Baz { get; set; }
    }
    
    public class Baz
    {
        public string MyString { get; set; }
    }
