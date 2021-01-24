    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        // ... more DbSets
    
        public List<TEntity> GetAll<TEntity>()
        {
            return Set<TEntity>().ToList();
        }
    
        // For entities that implement INamedEntity interface
        // with property Name.
        public TNamedEntity FindByName<TNamedEntity>(string name)
            where TNamedEntity : INamedEntity
        {
            return context.Set<TNamedEntity>()
                .FirstOrDefault(entity => entity.Name == name);
        }
    }
