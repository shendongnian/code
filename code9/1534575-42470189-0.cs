    IQueryable<DataRow> queryableData = IdTable.AsEnumerable().AsQueryable();
    // Get the generice "Field<string>(string)" method from DataRowExtensions
    ParameterExpression pe = Expression.Parameter(typeof(DataRow), "row");
    MethodInfo fieldMethod = typeof (DataRowExtensions).GetMethod("Field", new [] {typeof(DataRow),typeof(string)});
    MethodInfo genericFieldMethod = fieldMethod.MakeGenericMethod(typeof (string));
    Expression left = Expression.Call(null, genericFieldMethod, pe, Expression.Constant( col_name ));
    Expression right = Expression.Constant(value);
    Expression exp = Expression.Equal(left, right);
    IQueryable<DataRow> results = queryableData.Where(Expression.Lambda<Func<DataRow, bool>>(exp, pe));
