    public static class JsonExtensions
    {
    	public static object CreateModels<T>(this IEnumerable<T> models, string modelName = null)
    	{
    		modelName = modelName ?? typeof(T).Name+"Collection";
    
    		return new Dictionary<string, object>()
    		{
    			{ modelName, models.Select(m => CreateModel(m)) }
    		};
    	}
    
    	public static IDictionary<string, object> CreateModel<T>(this T model, string modelName = null)
    	{
    		modelName = modelName ?? typeof(T).Name;
    
    		return new Dictionary<string, object>()
    		{
    			{ modelName, GetProperties(model) }
    		};
    	}
    
    	private static IDictionary<string, object> GetProperties<T>(T obj)
    	{
    		var props = typeof(T).GetProperties();
    		return props.ToDictionary(p => p.Name, p => (object)new { type = p.PropertyType.ToString(), value = p.GetValue(obj, null).ToString() });
    	}
    }
