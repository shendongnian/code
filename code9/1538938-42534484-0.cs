    var ComparisonExpression = Expression.Equal(Expression.Call(
                               GetDateTimeValue(Expression.Invoke(searchColumnName, row)),
                               typeof(DateTime).GetMethod("CompareTo", new[] { typeof(DateTime) }),
                               Expression.Constant(toDate, typeof(DateTime))),
                               null);
