    public enum ConnectionConst
    {
    	[Description("Not Connected")]
    	NotConnected = 0,
    	[Description("Connected")]
    	Connected = 1,
    	[Description("Unknown")]
    	Unknown = 2
    }
    
    public static string DisplayEnumName(Enum value)
    {
    	var name = value.GetType().GetField(value.ToString());
    	var attributes = (DescriptionAttribute[])name.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
    	if (attributes != null && attributes.Length > 0) {
    		return attributes(0).Description;
    	} else {
    		return value.ToString();
    	}
    }
