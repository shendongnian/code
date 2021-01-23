    public static string GetDesc(MyEnum e)
    {
        var type = typeof(MyEnum);
        var memInfo = type.GetMember(e.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
            false);
        return ((DescriptionAttribute)attributes[0]).Description;
    }
    private static Expression<Func<MyEntity, Helper>> GetExpr()
    {
        var descMap = Enum.GetValues(typeof(MyEnum))
            .Cast<MyEnum>()
            .ToDictionary(value => value, GetDesc);
        var paramExpr = Expression.Parameter(typeof(MyEntity), "x");
        var expr = (Expression) Expression.Constant(string.Empty);
        foreach (var desc in descMap)
        {
            // Change string "Enum" below with your enum property name in entity
            var prop = Expression.Property(paramExpr, typeof(MyEntity).GetProperty("Enum")); 
            expr = Expression.Condition(Expression.Equal(prop, Expression.Constant(desc.Key)),
                Expression.Constant(desc.Value), expr);
        }
        var newExpr = Expression.New(typeof(Helper));
        var bindings = new MemberBinding[]
        {
            Expression.Bind(typeof(Helper).GetProperty("Entity"), paramExpr),
            Expression.Bind(typeof(Helper).GetProperty("Description"), expr)
        };
        var body = Expression.MemberInit(newExpr, bindings);
        return (Expression<Func<MyEntity, Helper>>) Expression.Lambda(body, paramExpr);
    }
