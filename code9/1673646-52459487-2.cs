    class AuditDeleteEntry : DelegatingEntry
    {
    	public AuditDeleteEntry(IUpdateEntry source) : base(source) { }
    	Dictionary<IPropertyBase, object> updatedValues;
    	public override object GetCurrentValue(IPropertyBase propertyBase)
    	{
    		if (updatedValues != null && updatedValues.TryGetValue(propertyBase, out var value))
    			return value;
    		return base.GetCurrentValue(propertyBase);
    	}
    	public override object GetOriginalValue(IPropertyBase propertyBase)
    	{
    		if (updatedValues != null && updatedValues.TryGetValue(propertyBase, out var value))
    			return value;
    		return base.GetOriginalValue(propertyBase);
    	}
    	public override void SetCurrentValue(IPropertyBase propertyBase, object value)
    	{
    		if (updatedValues == null) updatedValues = new Dictionary<IPropertyBase, object>();
    		updatedValues[propertyBase] = value;
    	}
    }
