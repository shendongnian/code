    public static void SetParameterValue<T>(this DataCommand cmd, Expression<Func<T>> expr)
    {
        MemberExpression member = expr.Body as MemberExpression;
        if (member == null)
            throw new ArgumentException("We need a member expression of type obj.PropertyName");
        PropertyInfo propInfo = member.Member as PropertyInfo;
        if (propInfo == null)
            throw new ArgumentException("We need a property, not a field");
        string name = propInfo.Name;
        T value = (T)expr.Compile()();
        cmd.Parameters.AddWithValue("@" + name, value);
    }
