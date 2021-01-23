    void Main()
    {
        new Child();
    }
    
    public class Parent 
    { 
        public Parent()
        {
            Console.WriteLine(this.GetType().Namespace);
        }
    }
    
    public class Child : Parent
    {
    }
