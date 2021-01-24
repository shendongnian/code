    public class A : INameable
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public class B : INameable
    {
       public string Name { get; set; }
       public string Description { get; set; }
    }
    
    public Interface INameable
    {
       string Name { get; set; }
    }
    public Enum Selector
    {
        A,
        B
    }
