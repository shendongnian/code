    public static Expression<Func<T, T>> ToExpressionGeneric<T>(this object Model) where T : new()
    {
        var type = typeof(T);
        var constructorinfo = type.GetConstructor(new Type[0]);
        var newExpression = Expression.New(constructorinfo);
        var memberInits = new List<MemberAssignment>();
        var modelProperties = Model.GetType().GetProperties();
        foreach (var prop in type.GetProperties())
        {
            var modelProperty = modelProperties.Where(t => t.Name == prop.Name.FirstLetterToLowerCase()).SingleOrDefault();
            if (modelProperty != null)
                memberInits.Add(Expression.Bind(prop, Expression.Constant(modelProperty.GetValue(Model, null))));
        }
        var expression = Expression.MemberInit(newExpression, memberInits);
        var p = Expression.Parameter(typeof(T), "p");
        return Expression.Lambda<Func<T, T>>(expression, p);
    }
    public static string FirstLetterToLowerCase(this string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("There is no first letter");
        char[] a = s.ToCharArray();
        a[0] = char.ToLower(a[0]);
        return new string(a);
    }
