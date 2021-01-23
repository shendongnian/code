    var memberNames = memberPath.Split('.');
    Expression value = Expression.Call(
        typeof(DataRowExtensions), "Field", new Type[] { columnType },
        source, Expression.Constant(memberNames[0]));
    for (int i = 1; i < memberNames.Length; i++)
        value = Expression.PropertyOrField(value, memberNames[i]);
    return value;
