    class Helper
    {
        public void Bar(A a)
        {
            a.Foo();
            InvokeFoo(a.Bs, foo => InvokeFoo(((B)foo).Ds));
            InvokeFoo(a.Cs);
        }
        void InvokeFoo(IEnumerable<IFoo> foos, Action<IFoo> childAction = null)
        {
            foreach (var foo in foos)
            {
                foo.Foo();
                childAction?.Invoke(foo);
            }
        }
    }
