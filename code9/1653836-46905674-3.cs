    public class Foo
    {
        public Foo() : this(0) 
        {
            Console.WriteLine("world");
        }
    
        public Foo(int param1)
        {
            Console.WriteLine("Hello");
        }
    }
    
    //...
    
    var foo = new Foo(); // outputs "Hello world"
