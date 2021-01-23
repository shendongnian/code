    public class Derived : Base
    {
        public Derived() 
            : base("Foo", 0f, 0f)
        {
    
        }
    
        public Base derived = new Derived();
    }
