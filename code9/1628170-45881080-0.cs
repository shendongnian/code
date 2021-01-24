    using System;
    using System.Collections.Generic;
    
    public class Base : IEquatable<Base>
    {
        public override bool Equals(object other)
        {
            Console.WriteLine("Equals(object)");
            return false;
        }
        
        public bool Equals(Base other)
        {
            Console.WriteLine("Equals(Base)");
            return false;
        }
        
        public override int GetHashCode() => 0;
    }
    
    public class Derived : Base
    {
    }
    
    public class Test
    {
    	static void Main()
        {
            var comparer = EqualityComparer<Derived>.Default;        
            Console.WriteLine(comparer.Equals(new Derived(), new Derived()));
        }
    }
