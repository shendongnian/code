    public static T GenerateRandomFields<T>() where T : new() {
        if (typeof(System.Collections.IList).IsAssignableFrom(typeof(T))) {
            var listType = typeof(T).GenericTypeArguments[0];
            MethodInfo method;
            if (!methods.TryGetValue(listType, out method))
                methods.Add(listType, method = genericMethod.MakeGenericMethod(listType));
            return (T)method.Invoke(null, new object[0]);
        }
        return default(T);
    }
