    public class MyFilter
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Operator { get; set; }
    }
	private Expression<Func<MyDTO, bool>> CreateLambda(MyFilter myFilter)
	{
		ParameterExpression parameter = Expression.Parameter(typeof(MyDTO), "m");
		Expression property = Expression.Property(parameter, myFilter.FieldName);
		Expression target = null;
		Expression exp = null;
		PropertyInfo pi = null;
		MethodInfo mi = null;
	
		var switchType = property.Type.ToString();
	
		switch (switchType)
		{
			case "System.DateTime":
				target = (myFilter.FieldValue == "null") ?
					Expression.Constant(null, property.Type) :
					Expression.Constant(Convert.ToDateTime(myFilter.FieldValue));
				switch (myFilter.Operator)
				{
					case "eq":
						exp = Expression.Equal(property, Expression.Convert(target, property.Type));
						break;
					case "ne":
						if (myFilter.FieldValue == "null")
						{
							exp = Expression.Property(property, "HasValue");
						}
						else
						{
							exp = Expression.NotEqual(property, Expression.Convert(target, property.Type));
						}
						break;
					case "ge":
						exp = Expression.GreaterThanOrEqual(property, Expression.Convert(target, property.Type));
						break;
					case "gt":
						exp = Expression.GreaterThan(property, Expression.Convert(target, property.Type));
						break;
					case "le":
						exp = Expression.LessThanOrEqual(property, Expression.Convert(target, property.Type));
						break;
					case "lt":
						exp = Expression.LessThan(property, Expression.Convert(target, property.Type));
						break;
				}
				break;
		}
		Expression<Func<MyDTO, bool>> lambda = Expression.Lambda<Func<MyDTO, bool>>(exp, parameter);
		return lambda;
	}
