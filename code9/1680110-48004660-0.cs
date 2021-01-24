    namespace FooTester.DoubleFoo.Foo
    {
        public abstract class FooBase
        {
            // Various generic properties and methods
        }
    
        public abstract class Foo<T> : FooBase 
        {
            public Type ValueType { get { return typeof(T); } }
            public abstract T Value { get; set; }
        }
    }
