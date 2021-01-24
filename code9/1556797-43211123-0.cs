    var collectionAccessMethod = method.Body as MethodCallExpression;
    if (collectionAccessMethod != null &&
            previousMethod.ReturnType.GetProperties()
            .Where(p => p.GetIndexParameters().Any())
            .Select(p => p.GetGetMethod())
            .Contains(collectionAccessMethod.Method))
    {
        var index = (int) Expression.Lambda(collectionAccessMethod.Arguments[0]).Compile().DynamicInvoke();
        var collection = ((Func<IEnumerable>)Expression.Lambda(previousMethod).Compile().DynamicInvoke()).Invoke();
        if (index > collection.Cast<object>().Count() - 1)
        {
            return true;
        }
    }
