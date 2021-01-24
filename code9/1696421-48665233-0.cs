    public static string convertEnum(int value, Type enumType) 
    {
    	if (!Enum.IsDefined(enumType, value))
    	{
    		throw new ArgumentException("Wrong call mate! gimme somthing to work with...");
    	}
    	
    	return Enum.ToObject(enumType, value).ToString();
    }
