	public static bool Similar(this Type reference, Type type)
	{
		if (reference.IsGenericParameter && type.IsGenericParameter)
		{
			return reference.GenericParameterPosition == type.GenericParameterPosition;
		}
		return ComparableType(reference) == ComparableType(type);
		Type ComparableType(Type cType)
			=> cType.IsGenericType ? cType.GetGenericTypeDefinition() : cType;
	}
