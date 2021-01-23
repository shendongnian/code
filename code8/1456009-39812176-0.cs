    MethodInfo equalsOperator = FindMethod(memberType, "op_Equality", false);
    equalityExpression = Expression.Equal(
        Expression.Property(left, memberInfo),
        Expression.Property(right, memberInfo),
        false,
        equalsOperator);
    ... 
    private static MethodInfo FindMethod(Type type, string methodName, bool throwIfNotFound = true)
    {
        TypeInfo typeInfo = type.GetTypeInfo();
        // TODO: Improve to search methods with a specific signature and parameters
        while (typeInfo != null)
        {
            IEnumerable<MethodInfo> methodInfo = typeInfo.GetDeclaredMethods(methodName);
            if (methodInfo.Any())
                return methodInfo.First();
            typeInfo = typeInfo.BaseType?.GetTypeInfo();
        }
        if (!throwIfNotFound)
            return null;
        throw new InvalidOperationException($"Type '{type.GetTypeInfo().FullName}' has no '{methodName}' method.");
    }
