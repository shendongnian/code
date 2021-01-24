    Expression ParseAggregate(Expression instance, Type elementType, string methodName, int errorPos)
    {
        // Change starts here
        var originalIt = it;
        var originalOuterIt = outerIt;
        // Change ends here
        outerIt = it;
        ParameterExpression innerIt = Expression.Parameter(elementType, elementType.Name);
        it = innerIt;
        Expression[] args = ParseArgumentList();
        // Change starts here
        it = originalIt;
        outerIt = originalOuterIt;
        // Change ends here
        MethodBase signature;
        if (FindMethod(typeof(IEnumerableSignatures), methodName, false, args, out signature) != 1)
