    public class DelegateDictionary
    {
    	Dictionary<Type, Delegate> Lookup;
    	
    	public DelegateDictionary()
    	{
    		Lookup = new Dictionary<System.Type, Delegate>();
    	}
    	
    	public void Add<T>(Func<T, string, string, XmlElement> mtd)
    	{
    		Lookup.Add(typeof(T), mtd);
    	}
    	
    	public XmlElement Invoke<T>(T value, string name, string namespaceURI)
    	{
    		if (!Lookup.TryGetValue(typeof(T), out var del)) throw new InvalidOperationException($"No delegate registered for {typeof(T).Name}");
    
    		var typedDel = (Func<T, string, string, XmlElement>)del;
    		return typedDel(value, name, namespaceURI);
    	}
    }
