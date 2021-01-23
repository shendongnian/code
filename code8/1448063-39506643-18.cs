    public static class Extensions
    {
    	
    	public static BinaryPropertyConfiguration Property<T>(this EntityTypeConfiguration<T> mapper, String propertyName) where T : class
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
    
    	public static byte[] ToBinary(this object instance)
    	{
    		if (instance == null)
    			throw new ArgumentNullException(nameof(instance));
    
    		using (var stream = new MemoryStream())
    		{
    			var formatter = new BinaryFormatter();
    			formatter.Serialize(stream, instance);
                return stream.ToArray();
    		}
    	}
    
    	public static object FromBinary(this byte[] buffer)
    	{
    		if (buffer == null)
    			throw new ArgumentNullException(nameof(buffer));
    		if (buffer.Length == 0)
    			throw new ArgumentOutOfRangeException(nameof(buffer), buffer.Length, "invalid buffer length.");
    
    		using (var stream = new MemoryStream(buffer, false))
    		{
    			var formatter = new BinaryFormatter();
    			var instance = formatter.Deserialize(stream);
    			return instance;
    		}
    	}
    }
