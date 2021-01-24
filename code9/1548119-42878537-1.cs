    public static T CreateAbstractInstance<T>() where T : class =>
        (T)Activator.CreateInstance(
            Thread.GetDomain()
                    .DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run)
                    .DefineDynamicModule("DynamicModule")
                    .DefineType("DynamicType", TypeAttributes.Public | TypeAttributes.Class, typeof(T))
                    .CreateType());
    private static TResult AbstractInvoke<TClass, TResult>(string methodName) where TClass : class
    {
        var method = typeof(TClass).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        var elegate = method.CreateDelegate(typeof(Func<BaseClass, TResult>));
        return (TResult)elegate.DynamicInvoke(CreateAbstractInstance<TClass>());
    }
    private static void Main()
    {
        var result = AbstractInvoke<BaseClass, int>("getValue");
        Console.WriteLine(result);
    }
