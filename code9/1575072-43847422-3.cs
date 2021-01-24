    var parX = Expression.Parameter(typeof(ClassA), "x");
    var list = Expression.Property(parX, nameof(ClassA.List));
    var listType = list.Type;
    var baseType = GetGenericIEnumerables(listType).First();
    var parY = Expression.Parameter(baseType, "y");
    var eq = Expression.Equal(
        Expression.Property(parX, nameof(ClassA.StringProperty)),
        Expression.Constant("X"));
    var gt = Expression.GreaterThan(
        Expression.Property(parY, "IntProperty"),
        Expression.Constant(1));
    var innerExpression = Expression.Lambda(gt, parY);
    var any = Expression.Call(
        anyT.MakeGenericMethod(baseType),
        list,
        innerExpression);
    var and = Expression.AndAlso(eq, any);
    var outerExpression = Expression.Lambda<Func<ClassA, bool>>(and, parX);
    var compiled = outerExpression.Compile();
    var result = objs.Where(compiled).ToArray();
