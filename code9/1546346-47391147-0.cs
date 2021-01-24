    public List<string> GetChangedProperties<T>(T a, T b) where T:class
    {	
    	if (a != null && b != null)
    	{
    		if (object.Equals(a, b))
    		{
    			return new List<string>();
    		}
    		var allProperties = a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    		return allProperties.Where(p => !object.Equals( p.GetValue(a),p.GetValue(b))).Select(p => p.Name).ToList();
    	}
    	else
    	{
    		var aText = $"{(a == null ? ("\"" + nameof(a) + "\"" + " was null") : "")}";
    		var bText = $"{(b == null ? ("\"" + nameof(b) + "\"" + " was null") : "")}";
    		var bothNull = !string.IsNullOrEmpty(aText) && !string.IsNullOrEmpty(bText);
    		throw new ArgumentNullException(aText + (bothNull ? ", ":"" )+ bText );
    	}
    }
