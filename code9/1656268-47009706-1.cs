    using System;
    
    struct Foo
    {
        public string x;
        public string y;
    }
    
    class Test
    {
        static void Main()
        {
            Foo foo = new Foo();
            foo.x = "x";
            foo.y = "y";
            Console.WriteLine(foo.GetHashCode());
            Console.WriteLine("x".GetHashCode());
            Console.WriteLine("y".GetHashCode());
        }
    }
