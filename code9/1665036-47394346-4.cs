    public interface IMyModelContext : IDisposable {
        DbSet<Contact> Contact { get; }
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //..other needed members
    }
