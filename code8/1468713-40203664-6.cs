    public static class EnumHelper
    {
    	public static Expression<Func<TSource, int>> DescriptionOrder<TSource, TEnum>(this Expression<Func<TSource, TEnum>> source)
    		where TEnum : struct
    	{
    		var enumType = typeof(TEnum);
    		if (!enumType.IsEnum) throw new InvalidOperationException();
    
    		var body = ((TEnum[])Enum.GetValues(enumType))
    			.OrderBy(value => value.GetDescription())
    			.Select((value, ordinal) => new { value, ordinal })
    			.Reverse()
    			.Aggregate((Expression)null, (next, item) => next == null ? (Expression)
    				Expression.Constant(item.ordinal) :
    				Expression.Condition(
    					Expression.Equal(source.Body, Expression.Constant(item.value)),
    					Expression.Constant(item.ordinal),
    					next));
    
    		return Expression.Lambda<Func<TSource, int>>(body, source.Parameters[0]);
    	}
    
    	public static string GetDescription<TEnum>(this TEnum value)
    		where TEnum : struct
    	{
    		var enumType = typeof(TEnum);
    		if (!enumType.IsEnum) throw new InvalidOperationException();
    
    		var name = Enum.GetName(enumType, value);
    		var field = typeof(TEnum).GetField(name, BindingFlags.Static | BindingFlags.Public);
    		return field.GetCustomAttribute<DescriptionAttribute>()?.Description ?? name;
    	}
    }
