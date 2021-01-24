    var types = AppDomain.CurrentDomain.GetAssemblies()
    	.SelectMany(s => s.GetTypes())
    	.Where(p => typeof(IDbConnection).IsAssignableFrom(p) && p.IsClass);
    
    foreach(var dbConnection in types)
    {
    	Console.WriteLine(dbConnection);
    }
