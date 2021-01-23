    public class DbSet<TEntity> 
        : DbQuery<TEntity>, 
          IDbSet<TEntity>, 
          IQueryable<TEntity>, 
          IEnumerable<TEntity>, 
          IQueryable, 
          IEnumerable 
          where TEntity : class
        //  M... O... U... S... EEEEE....
    {
