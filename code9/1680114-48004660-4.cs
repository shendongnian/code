    using FooTester.DoubleFoo.Foo
    
    namespace FooTester.DoubleFoo
    {
        public class DoubleFoo : Foo<double> 
        {
            public override double Value { get; set; }
        }
    }
