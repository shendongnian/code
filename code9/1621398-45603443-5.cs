    namespace MyNamespace
    {
    	public abstract class OpportunityModelDatabase : BaseDatabase
    	{
    		public static async Task<List<OpportunityModel>> GetAllOpportunityDataAsync()
    		{
    			var databaseConnection = await GetDatabaseConnection<OpportunityModel>().ConfigureAwait(false);
    
    			return await databaseConnection.Table<OpportunityModel>().ToListAsync().ConfigureAwait(false);
    		}
        }
    }
