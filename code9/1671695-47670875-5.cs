    Expression exp = Expression.Constant(""); //Default order key
    var p = Expression.Parameter(typeof(Entity));
    foreach (var kv in dict)
    {
        exp = Expression.Condition(
            Expression.Equal(
                Expression.Convert(
                    Expression.MakeMemberAccess(p, p.Type.GetProperty("Id")), typeof(int)
                ),
                Expression.Constant(kv.Key)
            ),
            Expression.Constant(kv.Value),
            exp
        );
    }
    var orderByExp = Expression.Lambda<Func<Entity, string>>(exp, p);
    var query = db.Entity.OrderBy(orderByExp);
