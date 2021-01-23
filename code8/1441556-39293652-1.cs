    using System;
    using System.Reflection;
    
    public class SomeClass<T>
    {
    
        public PropertyAClass A { get; set;}
        public PropertyBClass B { get; set;}
    
        public SomeClass (PropertyAClass A, PropertyBClass B)
        {
            this.A = A;
            this.B = B;
        }
    
        public static T operator +(T a, T b)
        {
            return new T(a.A + b.A, a.b + b.B);
        }
    }
    
    public class DerivedClass : SomeClass<DerivedClass>
    {
        public DerivedClass (PropertyADerivedClass A, PropertyBDerivedClass B) : base(A,B)
        {
        }
    }
