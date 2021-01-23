    public static MethodInfo GetAnyStaticMethodValidated(this Type type, string name, Type[] types)
    {
        // Method name is "op_Subtraction" in your case
        MethodInfo anyStaticMethod = type.GetAnyStaticMethod(name);
        // DateTime and DateTime in your case
        if (!anyStaticMethod.MatchesArgumentTypes(types))
        {
            return null;
        }
        return anyStaticMethod;
    }
    public static MethodInfo GetAnyStaticMethod(this Type type, string name)
    {
        foreach (MethodInfo current in type.GetRuntimeMethods())
        {
            if (current.IsStatic && current.Name == name)
            {
                return current;
            }
        }
        return null;
    }
