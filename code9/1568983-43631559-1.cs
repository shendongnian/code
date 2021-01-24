    public static void Main()
    {
       	var enumType = typeof (Foo<>.Bar);
		
		var underlyingType = Enum.GetUnderlyingType(enumType);
		
		foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
		{
			object value = field.GetValue(null);
			
			Console.WriteLine("{0} = {1}",value, Convert.ChangeType(value, underlyingType));
		}
    }
