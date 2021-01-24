    using System;
    
    public class Foo
    {
        public static void Main()
        {
            var foo = new Foo();
            Console.WriteLine(foo == null);
            Console.WriteLine(foo is null);
        }
    
        public static bool operator ==(Foo foo1, Foo foo2) => true;
        // operator != has to exist to appease the compiler
        public static bool operator !=(Foo foo1, Foo foo2) => false;
    }
