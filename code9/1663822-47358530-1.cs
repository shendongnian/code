    static void Validate(Expression<Action> expr)
    {
        var body = (MethodCallExpression)expr.Body;
        foreach (MemberExpression a in body.Arguments)
        {
            FieldInfo fi = a.Member as FieldInfo;
            ParameterInfo pi = body.Method.GetParameters().FirstOrDefault(p => p.Name == fi.Name);
            ValidationAttribute va = pi?.GetCustomAttribute<ValidationAttribute>();
            if (va != null)
                va.Validate(pi.Name, fi.GetValue(((ConstantExpression)a.Expression).Value));
        }
    }
