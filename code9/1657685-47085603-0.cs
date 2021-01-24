    var parmx = Expression.Parameter(QueryData.GetType(), "x");
    var parma = Expression.Parameter(QueryData[0].GetType(), "a");
    var abc2 = Expression.Lambda(Expression.Call(MyExtensions.GetMethodInfo((IEnumerable<Orders> x)=>x.OrderBy(a => a.customer[0].OtherAddress)),
                                                 new Expression[] { parmx,
                                                                    Expression.Lambda(Expression.Property(Expression.ArrayIndex(Expression.Property(parma, "customer"), Expression.Constant(0)), "OtherAddress"), new[] { parma }) }),
                                 new[] { parmx });
