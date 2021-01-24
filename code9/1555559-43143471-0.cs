	public string GetGenericArgumentType(Type type, string paramName)
	{
	    
	    var genericType = type.GetGenericTypeDefinition(); 
	    var genericParam = genericType
	        .GetGenericArguments()
	        .Select((t, i) => new { Index = i, t.Name })
	        .First(arg => arg.Name == paramName);
	    return type.GetGenericArguments()[genericParam.Index].Name;
	}
	class GenericFoo<TData, TSecondData> { }
	public void GetGenericArgumentTypeTest()
	{
	    string name1 = this.GetGenericArgumentType(
	    					typeof(GenericFoo<string, int>), "TData"); //String
	    string name2 = this.GetGenericArgumentType(
	    					typeof(GenericFoo<string, int>), "TSecondData"); //Int32
	}
