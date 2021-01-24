    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        // ... more DbSets
    
        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Set<TEntity>().ToList();
        }
    
        // For entities that implement INamedEntity interface
        // with property Name.
        public TNamedEntity FindByName<TNamedEntity>(string name)
            where TNamedEntity : INamedEntity, class
        {
            return Set<TNamedEntity>()
                .FirstOrDefault(entity => entity.Name == name);
        }
    }
