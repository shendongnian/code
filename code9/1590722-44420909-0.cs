    using(var src = new MyFirstContext())
    using(var tr = src.DataBase.BeginTransaction(IsolationLevel.ReadUncommited)) //this will speed up read of history
    {
    	int i = 0;
    	const int batchSize = 100000;
    	while(true)
    	{
    	    var batch = src.History.AsNoTracking().Skip(i*batchSize).Take(batchSize).ToList();
    	    if(!batch.Any())
    	    {
    	    	break;
    	    }
    	    using(var dst = new MySecondContext())
    		{
    			dst.Configuration.AutoDetectChangesEnabled = false;
    			foreach(var ent1 in batch)
    			{
    				var ent2 = Map(ent1); //here you can perform map of one history type of row to another.
    				dst.Set<Entity2>().Add(ent2);
    			}
    			dst.SaveChanges();
    		}
    		i++;
    	}
    }
