    public interface IActiveUserService
    {
        Task<bool> IsUserActiveAsync(Guid userId);
    }
    
    public class ActiveUserService : IActiveUserService
    {
        private readonly DbContext context;
    
        // I generally have DI inject a factory and I use that to create my DbContext instance (this is the prefered method)
        // for simplicity I have just pass DbContext
        // if you stick with this, 
        // you should make sure this service is constructed per request
        public ActiveUserService(DbContext context)
        {
            this.context = context;
        }
    
        public async Task<bool> IsUserActiveAsync(Guid userId) 
        {
             var connection = this.dbContext.Database.Connection   ;
    
             // I assume from this you are using Dapper??
             var param = new DynamicParameters();
             param.Add("@UserId", userId);
             var result = await connection
                                   .Query<TUser>(
                                       "IdentityCheckUserIsActive", 
                                       param, 
                                       commandType: CommandType.StoredProcedure)
                                   .SingleOrDefaultAsync();
    
             return result.IsActive;
        }
    }
