    // all methods with signature public static T Enumerable.Sum(IEnumerable<T>) by element type
    private static readonly Dictionary<Type, MethodInfo> _sumMethodsByElementType = typeof(Enumerable)
        .GetMethods(BindingFlags.Public | BindingFlags.Static)
        .Where(m => m.Name == "Sum" && !m.IsGenericMethod)
        .Select(m => new { Method = m, Parameters = m.GetParameters() })
        .Where(mp => mp.Parameters.Length == 1)
        .Select(mp => new { mp.Method, mp.Parameters[0].ParameterType })
        .Where(mp => mp.ParameterType.IsGenericType && mp.ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        .Select(mp => new { mp.Method, ElementType = mp.ParameterType.GetGenericArguments()[0] })
        .Where(me => me.Method.ReturnType == me.ElementType)
        .ToDictionary(mp => mp.ElementType, mp => mp.Method);
