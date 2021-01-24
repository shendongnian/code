    public static TypeCode GetTypeCode(Type type)
    {
    	if (type == null)
    		return TypeCode.Empty;
    	return type.GetTypeCodeImpl();
    }
    
    protected virtual TypeCode GetTypeCodeImpl()
    {
    	// System.RuntimeType overrides GetTypeCodeInternal
    	// so we can assume that this is not a runtime type
    
    	// this is true for EnumBuilder but not the other System.Type subclasses in BCL
    	if (this != UnderlyingSystemType && UnderlyingSystemType != null)
    		return Type.GetTypeCode(UnderlyingSystemType);
    	
    	return TypeCode.Object;
    }
