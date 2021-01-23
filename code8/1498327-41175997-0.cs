    interface IProcessA
    {
        void Method();
    }
    class B : IProcessA
    {
        readonly A _a;
        public B(A a)
        {
            _a = a;
        }
        public void Method()
        {
            // do something with _a
        }
    }
    class C : IProcessA
    {
        readonly A _a;
        public C(A a)
        {
            _a = a;
        }
        public void Method()
        {
            // do something different with _a
        }
    }
