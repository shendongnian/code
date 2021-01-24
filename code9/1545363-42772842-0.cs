    public static Expression AggregateFunc(IQueryable source, string member, string aggFunc) {
        PropertyInfo property = source.ElementType.GetProperty(member);
        FieldInfo field = source.ElementType.GetField(member);        
        ParameterExpression parameter = Expression.Parameter(source.ElementType, "f");
        Expression selector = Expression.Lambda(Expression.MakeMemberAccess(parameter, (MemberInfo) property ?? field), parameter);
        // Method
        // find correct method with two parameters: IQueryable and selector            
        MethodInfo method = typeof(Queryable).GetMethods().Where(c => c.GetParameters().Length == 2).First(m => m.Name == aggFunc);
        // some aggregates have two generic type arguments (such as min, max, average)
        // others like Sum have just one
        var genArgs = new List<Type>();
        genArgs.Add(source.ElementType);
        if (method.GetGenericArguments().Length > 1) {
            genArgs.Add(property?.PropertyType ?? field.FieldType);
        }
        return Expression.Call(
            null,
            method.MakeGenericMethod(genArgs.ToArray()),
            new[] {source.Expression, Expression.Quote(selector)});
    }
