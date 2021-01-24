    public interface IDbContext : IDisposable {
        int SaveContext();
        DbSet<TEntity> Set<TEntity>();
        //...other relevant EF members, etc
    }
    
    public interface IAppDbContext : IDbContext {
    
    }
    
    public interface ILogDbContext : IDbContext {
    
    }
