    // We already have the following commented properties
    // prop = "Project.CustomerId";
    // ParameterExpression param = Expression.Parameter(typeof(TaskItem), "task");
    var leftExpr = prop.Split('.')
                       .Aggregate<string, MemberExpression>(null, 
                          (acc, p) => acc == null 
                              ? Expression.Property(param, p) 
                              : Expression.Property(acc, p));
