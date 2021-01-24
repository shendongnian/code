      public class DbFactory : Disposable, IDbFactory
        {
            HomeCinemaContext dbContext;
    
       
     public HomeCinemaContext Init()
        {
            return dbContext ?? (dbContext = new HomeCinemaContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
    public class UnitOfWork : IUnitOfWork
        {
            private readonly IDbFactory dbFactory;
            private HomeCinemaContext dbContext;
    
            public UnitOfWork(IDbFactory dbFactory)
            {
                this.dbFactory = dbFactory;
            }
    
            public HomeCinemaContext DbContext
            {
                get { return dbContext ?? (dbContext = dbFactory.Init()); }
            }
    
            public void Commit()
            {
                DbContext.Commit();
            }
        }
     public class EntityBaseRepository<T> : IEntityBaseRepository<T>
                where T : class, IEntityBase, new()
        {
    
            private HomeCinemaContext dataContext;
    
            #region Properties
            protected IDbFactory DbFactory
            {
                get;
                private set;
            }
    
            protected HomeCinemaContext DbContext
            {
                get { return dataContext ?? (dataContext = DbFactory.Init()); }
            }
            public EntityBaseRepository(IDbFactory dbFactory)
            {
                DbFactory = dbFactory;
            }
            #endregion
            public virtual IQueryable<T> GetAll()
            {
                return DbContext.Set<T>();
            }
            public virtual IQueryable<T> All
            {
                get
                {
                    return GetAll();
                }
            }
            public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
            {
                IQueryable<T> query = DbContext.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query;
            }
            public T GetSingle(int id)
            {
                return GetAll().FirstOrDefault(x => x.ID == id);
            }
            public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
            {
                return DbContext.Set<T>().Where(predicate);
            }
    
            public virtual void Add(T entity)
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                DbContext.Set<T>().Add(entity);
            }
            public virtual void Edit(T entity)
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Modified;
            }
            public virtual void Delete(T entity)
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
        }
