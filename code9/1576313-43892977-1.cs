    // Sample data
    var db = new
    {
        Data = new[]
        {
            new ClassOne { ID = 1 },
            new ClassOne { ID = 2 },
            new ClassOne { ID = 3 },
        }.AsQueryable(),
    };
    var mytype = typeof(ClassOne);
    // Real code begins here
    var parameter = Expression.Parameter(mytype);
    var eq = Expression.Equal(Expression.Property(parameter, "ID"), Expression.Constant(2));
    // In truth lambdaExpression is Expression<Func<mytype, bool>>
    LambdaExpression lambdaExpression = Expression.Lambda(eq, parameter);
    // Search of mytype inside db
    // We look for the property that is implementing IQueryable<mytype>
    // We could lookup by name if the name is .mytype
    var iqueryableMyType = typeof(IQueryable<>).MakeGenericType(mytype);
    var prop = db.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Single(x => iqueryableMyType.IsAssignableFrom(x.PropertyType));
    // db.mytype value
    var propValue = prop.GetValue(db);
    // MyWhereHelper.Where<mytype>
    MethodInfo method = MyWhereHelper.WhereMethod.MakeGenericMethod(mytype);
    var myList = (IEnumerable<object>)method.Invoke(null, new object[] { propValue, lambdaExpression });
