    class Helper
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
                // Add more handling here as new subtypes are added
            };
        static void WalkFooHierarchy(IFoo foo)
        {
            foo.Foo();
            Action<IFoo> specialChildAction;
            if (SpecialClassActions.TryGetValue(foo.GetType(), out specialAction))
            {
                specialChildAction(foo);
            }
        }
        //  Replaces your Bar(IList<> ..) methods
        static void InvokeChildFoo(IEnumerable<IFoo> foos)
        {
            foreach (var foo in foos)
            {
                WalkFooHierarchy(foo);
            }
        }
