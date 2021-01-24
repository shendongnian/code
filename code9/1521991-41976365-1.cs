    [someAttribute()]
    private static int foo()
    {
        if (GetCurrentMethodAttribute<someAttribute>().Skip)
        {
            return 0;
        }
        return 1;
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static T GetCurrentMethodAttribute<T>() where T : Attribute
    {
        return (T)new StackTrace().GetFrame(1).GetMethod().GetCustomAttribute(typeof(T));
    }
