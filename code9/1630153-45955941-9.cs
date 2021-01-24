    class C2
    {
        private readonly Action<MyType> Method;
        public C2(Action<MyType> method)
        {
            this.Method = method;
        }
        // ...
        M2()
        {
            // call the delegate
            this.Method(instanceOfMytype);
        }
    }
