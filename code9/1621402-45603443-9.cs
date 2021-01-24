    namespace MyNamespace
    {
    	public class OpportunityModelDatabase : BaseDatabase
    	{
    		public async Task<List<OpportunityModel>> GetAllOpportunityDataAsync()
    		{
    			var databaseConnection = await GetDatabaseConnection<OpportunityModel>().ConfigureAwait(false);
    
    			return await databaseConnection.Table<OpportunityModel>().ToListAsync().ConfigureAwait(false);
    		}
        }
    }
