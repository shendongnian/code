    static void Main(string[] args)
    {
        var expr = GetExpression(t => t.Bar.Baz);
        var member = expr.Body as MemberExpression;
        // define new parameter of type object
        var target = Expression.Parameter(typeof(object), "t");
        var value =  Expression.Parameter(typeof(object), "p");
        // replace old parameter of type Foo to new one
        member = (MemberExpression) new ReplaceParameterExpressionVisitor(expr.Parameters[0], target).Visit(member);
        // convert value to target type, because you cannot assign object to string
        var assign = Expression.Assign(member, Expression.Convert(value, member.Type));
        // now we have (target, value) => ((Foo)target).Bar.Baz = (string) value;
        var lambda = Expression.Lambda<Action<object, object>>(assign, target, value);
        var o = new Foo();
        // set bar or will throw null reference
        o.Bar = new Bar();
        object v = "test";
        lambda.Compile().Invoke(o, v);
    }
