    void Main()
    {
        Foo foo = null;
        
        if (foo is null) Console.WriteLine("foo is null"); // This condition is met
        if (foo == null) Console.WriteLine("foo == null"); // This condition is NOT met
    }
    
    public class Foo
    {
        public static bool operator ==(Foo foo1, Foo foo2)
        {
            if (object.Equals(foo2, null)) return false;
            return object.Equals(foo1, foo2);
        }
        
        // ...
    }
