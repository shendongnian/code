    class A : ITest
    { 
        public virtual void fn()
        {
            Console.WriteLine("fn in A");
        }
    }
    class B : A
    {
        public override void fn()
        {
            Console.WriteLine("fn in B");
        }
    }
