    static Dictionary<Type, object> DefaultTypeValues = new Dictionary<Type, object>
    {
        { typeof(string), "" },
        { typeof(DateTime?), new DateTime(1753,1,1) } // Min date for sql date 
    };
    
    public static object GetDefaultValue(Type t)
    {
        object defaultValue;
        if(!DefaultTypeValues.TryGetValue(t, out defaultValue))
        {
            if(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                defaultValue = Activator.CreateInstance(t.GetGenericArguments().Single());
            }
            else
            {
                throw new NotSupportedException("Could not get default value for type " + t.FullName + " consider adding it in DefaultTypeValues");
            }
        }
        return defaultValue;
    }
    public static IOrderedQueryable<T> OrderBy<T>(IQueryable<T> srcQuery, string orderColumn, bool isAscending)
    {
        var type = typeof(T);
        var property = type.GetProperty(orderColumn);
    
        if (property == null)
            throw new Exception("Column property \"" + orderColumn + "\" does not exist on the type \"" + typeof(T).FullName + "\"");
    
        var parameter = Expression.Parameter(type, "p");
        // default sort is performed by o=> o.Prop
        Expression propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var propType = property.PropertyType;
    
        // If property is nullable we add teh null check 
        if (propType == typeof(string) || (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            var defaultValue = GetDefaultValue(propType);
            // If the property is nullable we sort by (o => o.Prop == null ? default(propType) : o.Prop)
            propertyAccess = Expression.Condition(
                Expression.Equal(propertyAccess, Expression.Constant(null, propType)),
                Expression.Constant(defaultValue, propType),
                propertyAccess
            );
        }
    
        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        MethodCallExpression resultExp = Expression.Call(typeof(Queryable), isAscending ? "OrderBy" : "OrderByDescending", new Type[] { type, propType },
        srcQuery.Expression, Expression.Quote(orderByExp));
    
        return (IOrderedQueryable<T>)srcQuery.Provider.CreateQuery<T>(resultExp);
    }
