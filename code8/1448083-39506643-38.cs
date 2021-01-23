    public static class Extensions
    {
    	
    	public static BinaryPropertyConfiguration BinaryProperty<T>(
            this EntityTypeConfiguration<T> mapper,
            String propertyName) where T : class
    	{
    		Type type = typeof(T);
    		ParameterExpression arg = Expression.Parameter(type, "x");
    		Expression expr = arg;
    
    		PropertyInfo pi = type.GetProperty(propertyName,
    			BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    		expr = Expression.Property(expr, pi);
    
    		LambdaExpression lambda = Expression.Lambda(expr, arg);
    
    		Expression<Func<T, byte[]>> expression = (Expression<Func<T, byte[]>>)lambda;
    		return mapper.Property(expression);
    	}
    
    	public static byte[] ToBinary<T>(this T instance)
    	{
            if (instance == null)
                return null;
    		using (var stream = new MemoryStream())
    		{
    			var formatter = new BinaryFormatter();
    			formatter.Serialize(stream, instance);
                return stream.ToArray();
    		}
    	}
    
    	public static T FromBinary<T>(this byte[] buffer)
    	{
            if (buffer == null)
                return default(T);
    		using (var stream = new MemoryStream(buffer, false))
    		{
    			var formatter = new BinaryFormatter();
    			var instance = formatter.Deserialize(stream);
    			return (T)instance;
    		}
    	}
    }
