    public static class Init
    {
    	public static void Initalize(DbContext[] contexts, Config.Options.Environments environment)
    	{                     
    		if (environment == Config.Options.Environments.Development)
    		{
    			foreach(DbContext cntx in contexts)
    			{
    				if (cntx.GetType().Equals(typeof(GenericDbContext)))
    				{
    					cntx.Database.EnsureDeleted();
    					cntx.Database.EnsureCreated();
    				}
    			}
    
    			var clients = new Client[]
    			{
    				new Client() { Key = Guid.NewGuid(), Name = "Smokers.no", DisplayName = "Smokers.no", Email = "post@smokers.no", LogoFilename = "logo.jpg" }
    			};
    
    			foreach(DbContext cntx in contexts)
    			{
    				if (cntx.GetType().Equals(typeof(GenericDbContext)))
    				{
    					var context = cntx as GenericDbContext;
    					foreach (Client client in clients) { context.Clients.Add(client); }
    					context.SaveChanges();
    				}
    			}
    		}
    		else
    		{
    			foreach(DbContext cntx in contexts)
    			{
    				cntx.Database.EnsureCreated();
    
    				if (cntx.GetType().Equals(typeof(GenericDbContext)))
    				{
    					var context = cntx as GenericDbContext;
    					if (context.Clients.Any())
    					{
    						return;
    					}
    				}
    			}
    		}
    	}
    }
