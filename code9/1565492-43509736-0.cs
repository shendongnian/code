    class A
    {
    }
    class B
    {
    }
    class C
    {
        private A _a;
        private B _b = new B(); // B's constructor will be called here. It will be executed before C's constructor
        public C()
        {
            _a = new A(); // A's constructor will be called here
        }
    }
