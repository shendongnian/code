    public class Parent 
    { 
        public Parent(string name)
        {
            Console.WriteLine(name);
        }
    }
    
    public class Child : Parent
    {
        public Child(): base(typeof(Child).Namespace)
        {
            
        }
    }
