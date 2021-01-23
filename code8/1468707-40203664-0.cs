    public static class EnumHelper
    {
    	public static Expression<Func<TSource, int>> DescriptionOrder<TSource, TEnum>(this Expression<Func<TSource, TEnum>> source)
    		where TEnum : struct
    	{
    		var enumType = typeof(TEnum);
    		if (!enumType.IsEnum) throw new InvalidOperationException();
    
    		var body = ((TEnum[])Enum.GetValues(enumType))
    			.Select((value, index) => new { value, index })
    			.OrderByDescending(item => item.value.GetDescription()) // reverse order
    			.Aggregate((Expression)null, (next, item) => next == null ? (Expression)
    				Expression.Constant(item.index) :
    				Expression.Condition(
    					Expression.Equal(source.Body, Expression.Constant(item.value)),
    					Expression.Constant(item.index),
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
