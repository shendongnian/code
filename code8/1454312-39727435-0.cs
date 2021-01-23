    public class BaseUnitOfWork : IUnitOfWork
      {
            public DbContext _Context { get; private set; }
    
    
            public BaseUnitOfWork(DbContext context)
            {
    
                this._Context = context;
            }
    
            public async Task<int> Save()
            {
                try
                {
                    var ret =  await this._Context.SaveChangesAsync();
                    return ret;
                }catch(Exception ex)
                {
                    // log the error here 
                    return 0;
                }
              }
        }
