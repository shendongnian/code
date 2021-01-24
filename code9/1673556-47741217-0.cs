    static bool IsMethodImplementationOfInterface(Type interfaceType,MethodInfo method)
    {
        return method.ReflectedType.GetInterfaceMap(interfaceType).TargetMethods.Contains(method);
    }
    foreach (var methodInfo in typeof(TestImpl).GetMethods())
    {
        if (IsMethodImplementationOfInterface(typeof(ITest), methodInfo))
        {
            //Logic
        }
    }
