    private static void Sync<T>(string tableName, ISession session, ISession syncSession)
    {
        Console.WriteLine("Fetching data for ####{0}####...", tableName);
        var sqlLinks = session.Query<T>();
        var links = sqlLinks.ToList();
        Console.WriteLine("...Done");
    
    	Console.WriteLine("Evicting data...");
    	links.ForEach(x => session.Evict(x));
    	Console.WriteLine("...Done");
    
    	Console.WriteLine("Saving data...");
    	var bindRefs = GetRefBindActions<T>(syncSession.SessionFactory).ToList();
    	foreach (var link in links)
    	{
    		foreach (var action in bindRefs) action(syncSession, link);
    		syncSession.Save(link);
    	}
    	Console.WriteLine("...Flushing data...");
        syncSession.Flush();
        Console.WriteLine("...Done");
        Console.WriteLine("\n\n\n");
    }
 
