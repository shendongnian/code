    var param = Expression.Parameter(typeof(object), "o");
    // IComparable comparable;
    var comparableDeclare = Expression.Parameter(typeof(IComparable), "comparable");
    // comparable = o as IComparable;
    var comparableAssign = Expression.Assign(comparableDeclare, Expression.TypeAs(param, typeof(IComparable)));
    // if (comparable == (IComparable)null) 
    // {
    //    throw new ArgumentException("The parameter must be a instance of IComparable.", nameof(o));
    // }
    var comparableCheck = Expression.IfThen(Expression.Equal(comparableDeclare, Expression.Constant(null, typeof(IComparable))),
         ThrowNotTypeOf(typeof(IComparable), param.Name));
    var formattableDeclare = Expression.Parameter(typeof(IFormattable), "formattable");
    // formattable = o as IFormattable;
    var formattableAssign = Expression.Assign(formattableDeclare, Expression.TypeAs(param, typeof(IFormattable)));
    // if (formattable == (IFormattable)null) 
    // {
    //    throw new ArgumentException("The parameter must be a instance of IFormattable.", nameof(o));
    // }
    var formattableCheck = Expression.IfThen(
        Expression.Equal(formattableDeclare, Expression.Constant(null, typeof(IFormattable))),
        ThrowNotTypeOf(typeof(IFormattable), param.Name));
    var block = Expression.Block(
        new [] {
            comparableDeclare, formattableDeclare
        }, // local variables
        comparableAssign, comparableCheck, formattableAssign, formattableCheck);
    foreach (var exp in block.Expressions)
    {
        Console.WriteLine(exp);
    }
    // Compile the expression tree
    var method = Expression.Lambda<Action<object>>(block, param).Compile();
    method.Invoke(new ComparableFormattable());
