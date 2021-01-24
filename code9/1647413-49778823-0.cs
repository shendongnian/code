    static bool hasCapturedValues(Action a) { return isStatic(a.Method); }
    static bool hasCapturedValues(System.Reflection.MethodInfo methodInfo)
    {
        var fields = methodInfo.DeclaringType.GetFields(BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Static |
                        BindingFlags.Instance |
                        BindingFlags.DeclaredOnly).ToList();
        return methodInfo.IsStatic|| fields.All(f=>f.IsStatic);
    }
