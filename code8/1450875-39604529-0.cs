            internal static MethodInfo GetAnyStaticMethodValidated(
            this Type type,
            string name,
            Type[] types)
        {
            foreach (var method in type.GetRuntimeMethods())
            {
                if (method.IsStatic && method.Name == name && method.MatchesArgumentTypes(types))
                {
                    return method;
                }
            }
            return null;
        }
