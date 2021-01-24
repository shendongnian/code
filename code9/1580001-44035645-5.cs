    public T ToEntity<T>() where T : Entity
    {
    	if (typeof(T) == typeof(Entity))
    	{
    		Entity entity = new Entity();
    		this.ShallowCopyTo(entity);
    		return entity as T;
    	}
    	if (string.IsNullOrWhiteSpace(this._logicalName))
    	{
    		throw new NotSupportedException("LogicalName must be set before calling ToEntity()");
    	}
    	string text = null;
    	object[] customAttributes = typeof(T).GetCustomAttributes(typeof(EntityLogicalNameAttribute), true);
    	if (customAttributes != null)
    	{
    		object[] array = customAttributes;
    		int num = 0;
    		if (num < array.Length)
    		{
    			EntityLogicalNameAttribute entityLogicalNameAttribute = (EntityLogicalNameAttribute)array[num];
    			text = entityLogicalNameAttribute.LogicalName;
    		}
    	}
    	if (string.IsNullOrWhiteSpace(text))
    	{
    		throw new NotSupportedException("Cannot convert to type that is does not have EntityLogicalNameAttribute");
    	}
    	if (this._logicalName != text)
    	{
    		throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Cannot convert entity {0} to {1}", new object[]
    		{
    			this._logicalName,
    			text
    		}));
    	}
    	T t = (T)((object)Activator.CreateInstance(typeof(T)));
    	this.ShallowCopyTo(t);
    	return t;
    }
