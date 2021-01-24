    class BaseClass
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }
    }
    class DerivedClass : BaseClass
    {
        public void Method1() // DerivedClass.Method1() hides inherited memeber BaseClass.Method1(). Use the new keyword if hiding was intended.
        {
            Console.WriteLine("Derived - Method1");
        }
    }
