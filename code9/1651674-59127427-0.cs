    public class MyObjectComparer : IEqualityComparer<MyObject>
    {
    	public bool Equals(MyObject a, MyObject b)
    	{
    		var properties = a.GetType().GetProperties();
    		foreach (var prop in properties)
    		{
    			var valueOfProp1 = prop.GetValue(a);
    			var valueOfProp2 = prop.GetValue(b);
    
    			if (!valueOfProp1.Equals(valueOfProp2))
    			{
    				return false;
    			}
    		}
    
    		return true;
    	}
    
    	public int GetHashCode(MyObject item)
    	{
    		return item.A.GetHashCode();
    	}
    }
