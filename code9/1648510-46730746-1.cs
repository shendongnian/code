    public static MethodInfo GetMethodWithGenerics(
                                this Type type,
                                string name, Type[] parameters,
                                BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
    {
        var methods = type.GetMethods(flags);
        foreach (var method in methods)
        {
            var parmeterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
            if (method.Name == name && parmeterTypes.Count() == parameters.Length)
            {
                bool match = true;
                for (int i = 0; i < parameters.Length; i++)
                    match &= parmeterTypes[i].Similar(parameters[i]);
                if (match)
                    return method;
            }
        }
        return null;
    }
