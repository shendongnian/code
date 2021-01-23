    var terms = search_string.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    var varExpr = Expression.Variable(typeof(YourClass), "x");
    var strContainsMethodInfo = typeof(string).GetMethod("Contains");
    var propInfo = typeof(YourClass).GetProperty("Description");
    var falseExpr = (Expression) Expression.Constant(false);
    var body = terms
        .Select(Expression.Constant)
        .Select(con => Expression.Call(Expression.Property(varExpr, propInfo), strContainsMethodInfo, con))
        .Aggregate(falseExpr, Expression.OrElse);
    var lamb = (Expression<Func<YourClass, bool>>)Expression.Lambda(body, varExpr);
    var att = db.AttributesTable
                .Where(lamb);
    return View(att.ToList());
