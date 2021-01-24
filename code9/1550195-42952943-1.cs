    public void AddExpression<T1, T2>(Expression<Func<T1, T2>> e)
    {
        var originalParameter = e.Parameters[0];
        // object par1
        var parameter = Expression.Parameter(typeof(object), originalParameter.Name);
        // T1 var1
        var variable = Expression.Variable(typeof(T1), "var1");
        // (T1)par1
        var cast1 = Expression.Convert(parameter, typeof(T1));
        // var1 = (T1)par1;
        var assign1 = Expression.Assign(variable, cast1);
        // The original body of the expression, with originalParameter replaced with var1
        var body = new SimpleParameterReplacer(originalParameter, variable).Visit(e.Body);
        // (object)body (a cast to object, necessary in the case T2 is a value type. If it is a reference type it isn't necessary)
        var cast2 = Expression.Convert(body, typeof(object));
        // T1 var2; var1 = (T1)par1; (object)body;
        // (the return statement is implicit)
        var block = Expression.Block(new[] { variable }, assign1, cast2);
        var e2 = Expression.Lambda<Func<object, object>>(block, parameter);
        _expressions.Add(e2);
    }
