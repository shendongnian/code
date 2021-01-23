    var query = db.Documents.AsQueryable();
    // query.GroupBy(a => 1)
    var a = Expression.Parameter(typeof(Document), "a");
    var groupKeySelector = Expression.Lambda(Expression.Constant(1), a);
    var groupByCall = Expression.Call(typeof(Queryable), "GroupBy",
    	new Type[] { a.Type, groupKeySelector.Body.Type },
    	query.Expression, Expression.Quote(groupKeySelector));
    // c => c.Amount
    var c = Expression.Parameter(typeof(Document), "c");
    var sumSelector = Expression.Lambda(Expression.PropertyOrField(c, "Amount"), c);
    // b => b.Sum(c => c.Amount)
    var b = Expression.Parameter(groupByCall.Type.GetGenericArguments().Single(), "b");
    var sumCall = Expression.Call(typeof(Enumerable), "Sum",
    	new Type[] { c.Type },
    	b, sumSelector);
    // query.GroupBy(a => 1).Select(b => b.Sum(c => c.Amount))
    var selector = Expression.Lambda(sumCall, b);
    var selectCall = Expression.Call(typeof(Queryable), "Select",
    	new Type[] { b.Type, selector.Body.Type },
    	groupByCall, Expression.Quote(selector));
    // selectCall is our expression, let test it
    var result = query.Provider.CreateQuery(selectCall);
