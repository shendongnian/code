    using System;
    using System.Reflection;
    
    class Base
    {
        public int Foo { get; set; }
    }
    
    class Child : Base
    {    
    }
    
    class Test
    {
        static void Main()
        {
            var baseProp = typeof(Base).GetProperty("Foo");
            var childProp = typeof(Child).GetProperty("Foo");
            Console.WriteLine(baseProp.Equals(childProp));
            Console.WriteLine(baseProp.ReflectedType);
            Console.WriteLine(childProp.ReflectedType);
        }
    }
