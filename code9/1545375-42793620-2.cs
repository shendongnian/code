    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
         protected DbContext Context;
         //this is the constructor for your base repositories
         public Repository(DbContext context)
         {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
            Context = context;
        }
        public void Save(TEntity entity)
        {
            Save(entity);
        }
        public void Save(TEntity entity)
        {
            if (entity == null) return;
            if (entity.Id == 0)
            {
                Add(entity);
            }
            else
            {
                //state is modified
                Context.Entry(entity).State = EntityState.Modified;
                Context.Set<TEntity>().Attach(entity);
            }
        }
