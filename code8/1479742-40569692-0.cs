        //The actual method to find all extension methods in the assembly 
        //that take IEnumerable<TSource> or TSource as parameters.
        public static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,Type extendedType)
        {
             var query = from type in assembly.GetTypes()
             where type == typeof(Enumerable)
             from method in type.GetMethods(BindingFlags.Static
             | BindingFlags.Public | BindingFlags.NonPublic)
             where method.IsDefined(typeof(ExtensionAttribute), false)
             where (method.GetParameters()[0].ParameterType.IsGenericType 
             | (method.GetParameters()[0].ParameterType.ContainsGenericParameters)
             select method;
             return query;
        }
        //Get the assembly System.Linq
        Assembly thisAssembly = Assembly.GetAssembly(typeof(Enumerable));
        foreach (MethodInfo method in GetExtensionMethods(thisAssembly,
            typeof(string)))
        {
            Console.WriteLine(method);
        }
