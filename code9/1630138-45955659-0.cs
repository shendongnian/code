	public static void Main()
	{
		Myclass test = new Myclass();
	
		var field = GetInheritedPrivateField(test.GetType(), "testValue");
		field.SetValue(test, 3);
	}
	private static FieldInfo GetInheritedPrivateField(Type type, string fieldName)
	{
		do
		{
			var field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
			
			if (field != null)
			{
				return field;
			}
			
			type = type.BaseType;
		} 
		while (type != null);
		
		return null;
	}
