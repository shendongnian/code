    class A : ITest
    { 
        void ITest.fn()
        {
            FnCore();
        }
        protected virtual void FnCore()
        {
            Console.WriteLine("fn in A");
        }
    }
    class B : A
    {
        public override void FnCore()
        {
            Console.WriteLine("fn in B");
        }
    }
