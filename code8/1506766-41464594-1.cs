    public sealed class DynamicWrapper : DynamicObject
    {
    	public DynamicWrapper(object target)
    	{
    		Target = target;
            // We store property names and property metadata in a dictionary
            // to speed up things later (we'll find if a requested
            // property exists with a time complexity O(1)!)
    		TargetProperties = target.GetType()
    									.GetProperties(BindingFlags.Instance | BindingFlags.Public)
    									.ToDictionary(p => p.Name, p => p);
    		
    	}
    	
    	private IDictionary<string, PropertyInfo> TargetProperties { get; }
    	private object Target { get; }
    	
    	
    	public override bool TrySetMember(SetMemberBinder binder, object value)
    	{
            // We don't support setting properties!
    		throw new NotSupportedException();
    	}
    	
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		PropertyInfo property;
    		
    		if(TargetProperties.TryGetValue(binder.Name, out property))
    		{
    			result = property.GetValue(Target);	
    			
    			return true;
    		}
    		else
    			
    		{
    			result = null;
    			
    			return false;
    		}
    	}
    }
