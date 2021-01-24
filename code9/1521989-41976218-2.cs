    private static int foo()
    {
        // some foo code
        return 1;
    }
    [someAttribute(Skip=true)]
    private static int foo(int arg)
    {
        if (typeof(ProgramTest).GetMethod(nameof(foo), 
                            BindingFlags.Static | BindingFlags.NonPublic,
                            null, // use default binder
                            new Type[] {typeof(int)}, // list of parameter types
                            null) // array of parameter modifiers
                    .GetCustomAttribute<someAttribute>()?.Skip ?? false)
            return 0;
        return arg;
    }
