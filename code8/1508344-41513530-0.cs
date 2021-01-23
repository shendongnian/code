    public static bool IsDefinedInEnum(this Enum value, Type enumType)
    {
	    if (!value.GetType().IsAssignableFrom(enumType))
			return false;
			
		return Enum.IsDefined(enumType, value);
	}
