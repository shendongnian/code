    public void RunOnAll<T>(Action<T> action) 
    {
    	var instances = AppDomain.CurrentDomain.GetAssemblies()
    		.SelectMany(a => a.GetTypes())
    		.Where(t => t.IsClass && typeof(T).IsAssignableFrom(t))
    		.Select(t => (T)Activator.CreateInstance(t));
    
    	foreach (var instance in instances)
    	{
    		action(instance);
    	}
    }
