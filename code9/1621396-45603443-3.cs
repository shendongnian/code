    namespace MyNamespace
    {
    	public abstract class OpportunityModelDatabase : BaseDatabase
    	{
    		public static async Task<List<OpportunityModel>> GetAllOpportunityDataAsync()
    		{
    			var databaseConnection = await GetDatabaseConnectionAsync();
    
    			return await databaseConnection.Table<OpportunityModel>().ToListAsync();
    		}
        }
    }
