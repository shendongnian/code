    class Helper2
    {
        private static readonly IDictionary<Type, Action<IFoo>> SpecialClassActions 
            = new Dictionary<Type, Action<IFoo>>
            {
                // Provide special handling for walking classes which have children
                {
                    typeof(A),
                    foo =>
                    {
                        InvokeChildFoo(((A)foo).Bs);
                        InvokeChildFoo(((A)foo).Cs);
                    }
                },
                {
                    typeof(B),
                    foo =>
                    {
                        InvokeChildFoo(((B)foo).Ds);
                    }
                }
            };
        static void WalkFooHierarchy(IFoo foo)
        {
            foo.Foo();
            Action<IFoo> specialAction;
            if (SpecialClassActions.TryGetValue(foo.GetType(), out specialAction))
            {
                specialAction(foo);
            }
        }
        static void InvokeChildFoo(IEnumerable<IFoo> foos)
        {
            foreach (var foo in foos)
            {
                WalkFooHierarchy(foo);
            }
        }
