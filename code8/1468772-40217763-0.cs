    public static void ExecuteCypher(List<Statement> statements)
    {
    	List<IStatementResult> results = new List<IStatementResult>();
    
    	using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("user", "pass")))
    	{
    		using (var session = driver.Session())
    		{
    			using (var tx = session.BeginTransaction())
    			{
    				foreach (var statement in statements)
    				{
    					results.Add(tx.Run(statement));
    				}
    
    				tx.Success();
    			}
    		}
    	}
    }
