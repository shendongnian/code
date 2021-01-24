      void Main()
    {
    	JsonConvert.DeserializeAnonymousType(U.InputText(), new Dictionary<int, object> { })
    	.ToDictionary(a=>a.Key,a=> ((JObject) a.Value).ToAnonymous(new { _bnd = new {_path=""}})).Dump();	
    }
    
    public static class ext
    {
    	public static T ToAnonymous<T>(this JObject source, T obj) => (T)source.ToObject(obj.GetType());
    }
