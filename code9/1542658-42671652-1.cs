    class Base
    {
        public virtual void Index() { }
    }
    class Derived : Base
    {
        public override void Index() { } // here is the override.
        long Id { get; set; }
        string SomeValue { get; set; }
    }
