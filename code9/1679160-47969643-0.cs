    using System.Dynamic;
    class Dynamo : DynamicObject
    {
    	private Dictionary<string, object> items = new Dictionary<string, object>();
    
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		return items.TryGetValue(binder.Name, out result);
    	}
    
    	public override bool TrySetMember(SetMemberBinder binder, object value)
    	{
    		items[binder.Name] = value;
    		return true;
    	}
    
    	public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
    	{
    		string propName = indexes[0] as string;
    		items[propName] = value;
    		return true;
    	}
    
    	public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
    	{
    		string propName = indexes[0] as string;
    		return items.TryGetValue(propName, out result);
    	}
        public override IEnumerable<string> GetDynamicMemberNames()
        {
    	    return items.Keys;
        }
    }
