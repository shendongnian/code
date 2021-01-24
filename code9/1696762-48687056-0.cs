    try
    {
    	var connection = new SqlConnection("[ConnectionString]");
    	var trans = connection.BeginTransaction();
    
    	while (condition)
    	{
    		using (TestContext context = new TestContext(connection))
    		{
                 // ...code..
    		}
    	}
    
    	trans.Commit();
    }
    catch
    {
    	// ...code..
    }
    			
    public class TestContext : DbContext
    {
    	public TestContext(SqlConnection connection) : base(connection, false)
    	{
    		
    	}
    	
    	// ...code...
    }
