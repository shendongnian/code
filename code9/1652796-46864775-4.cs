    public static void SetParameterValue<T>(this DataCommand cmd, Expression<Func<T>> expr)
    {
        var member = expr.Body as MemberExpression;
        if (member == null)
            throw new ArgumentException("We need a member expression of type obj.PropertyName");
        var prop = member.Member as PropertyInfo;
        if (prop == null)
            throw new ArgumentException("We need a property, not a field");
        string name = prop.Name;
        T value = expr.Compile()();
        cmd.Parameters.AddWithValue("@" + name, value);
    }
