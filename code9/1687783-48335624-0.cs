    public interface ICustomRepository : IRepository<Custom, int>
    {
    
    }
    
    public class CustomRepository : CustomRepositoryBase<Custom, int>, ICustomRepository
    {
    public CustomRepository(IDbContextProvider<CustomDbContext> dbContextProvider,
    		IObjectMapper objectMapper)
    	: base(dbContextProvider, objectMapper)
    	{
    	}
    }
