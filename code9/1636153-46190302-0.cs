    public class GenericDataAccess<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntityBase
        {
            internal ELearningDBContext ELearningDBContext;
            internal DbSet<TEntity> ELearningDBSet;
    
            public GenericDataAccess(ELearningDBContext context)
            {
                this.ELearningDBContext = context;
                this.ELearningDBSet = context.Set<TEntity>();
            }
            public virtual PagingModel<TEntity> GetAllPaged(int pagesize, NameValueCollection queryString)
            {
                return ELearningDBSet.AsQueryable().OrderByDescending(o => o.Id).ToList();
            }
         }
