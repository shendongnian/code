    private static void Assign<T1, T2>(T1 T1Obj, T2 T2Obj, Expression<Func<T1, object>> memberLamda)
	{
		var memberSelectorExpression = memberLamda.Body as MemberExpression;
		if (memberSelectorExpression != null)
		{
			var sourceProperty = memberSelectorExpression.Member as PropertyInfo;
			
			if (sourceProperty != null)
			{
				var targetProperty = T2Obj.GetType().GetProperty(sourceProperty.Name);
				if (targetProperty != null)
				{
					targetProperty.SetValue(T2Obj, GetValue(T1Obj, memberSelectorExpression));
				}
			}
		}
	}
    public static object GetValue<T>(T source, MemberExpression expr)
    {
        var sourceProperty = expr.Member as PropertyInfo;
        var nextExpression = expr.Expression as MemberExpression;
        if (nextExpression == null)
        {
            return sourceProperty.GetValue(source);
        }
        var sourcePart = GetValue(source, nextExpression);
        return sourceProperty.GetValue(sourcePart);
    }
