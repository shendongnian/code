    static class MyClass
    {
    	public static string DescriptionAttr<T>(this T source, Type attrType, string propertyName)
    	{
    		FieldInfo fi = source.GetType().GetField(source.ToString());
    
    		var attributes = fi.GetCustomAttributes(attrType, false);
    
    		if (attributes != null && attributes.Length > 0)
    		{
    			var propertyInfo = attributes[0].GetType().GetProperty(propertyName);
    
    			if (propertyInfo != null)
    			{
    				var value = propertyInfo.GetValue(attributes[0], null);
    				return value as string;
    			}
    		}
    		else
    			return source.ToString();
    
    		return null;
    	}
    }
    
    public enum MyEnum
    {
    	Name1 = 1,
    	[MyAttribute("Here is another")]
    	HereIsAnother = 2,
    	[MyAttribute("Last one")]
    	LastOne = 3
    }
    
    class MyAttribute : Attribute
    {
    	public string Description { get; set; }
    
    	public MyAttribute(string desc)
    	{
    		Description = desc;
    	}
    }
