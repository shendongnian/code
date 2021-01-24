**Base Interface :** 
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Detach(T entity);
        void Delete(T entity);
        T GetById(long Id);
        T GetById(string Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        void Commit();
    }
**Abstract Class :**
     public abstract class Repository<T> : IRepository<T> where T : class
        {
            private Database_DBEntities dataContext;
            private readonly IDbSet<T> dbset;
            protected Repository(IDatabaseFactory databaseFactory)
            {
                DatabaseFactory = databaseFactory;
                dbset = DataContext.Set<T>();
                
            }
            /// <summary>
            /// Property for the databasefactory instance
            /// </summary>
            protected IDatabaseFactory DatabaseFactory
            {
                get;
                private set;
            }
            /// <summary>
            /// Property for the datacontext instance
            /// </summary>
            protected Database_DBEntities DataContext
            {
                get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
            }
            /// <summary>
            /// For adding entity
            /// </summary>
            /// <param name="entity"></param>
            public virtual void Add(T entity)
            {
                try
                {
                    dbset.Add(entity);
                    //  dbset.Attach(entity);
                    dataContext.Entry(entity).State = EntityState.Added;
                    int iresult = dataContext.SaveChanges();
                }
                catch (UpdateException ex)
                {
                   
                }
                catch (DbUpdateException ex) //DbContext
                {
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// For updating entity
            /// </summary>
            /// <param name="entity"></param>
            public virtual void Update(T entity)
            {
                try
                {
                    // dbset.Attach(entity);
                    dbset.Add(entity);
                    dataContext.Entry(entity).State = EntityState.Modified;
                    int iresult = dataContext.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw new ApplicationException(Embracing_Culture_ResourceFile.DuplicateMessage, ex);
                }
                catch (DbUpdateException ex) //DbContext
                {
                    throw new ApplicationException(Embracing_Culture_ResourceFile.DuplicateMessage, ex);
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
         
            /// <summary>
            /// for deleting entity with class 
            /// </summary>
            /// <param name="entity"></param>
            public virtual void Delete(T entity)
            {
                dbset.Remove(entity);
                int iresult = dataContext.SaveChanges();
            }
           
            //To commit save changes
            public void Commit()
            {
                //still needs modification accordingly
                DataContext.SaveChanges();
            }
            /// <summary>
            /// Fetches values as per the int64 id value
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual T GetById(long id)
            {
                return dbset.Find(id);
            }
            /// <summary>
            /// Fetches values as per the string id input
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public virtual T GetById(string id)
            {
                return dbset.Find(id);
            }
            /// <summary>
            /// fetches all the records 
            /// </summary>
            /// <returns></returns>
            public virtual IEnumerable<T> GetAll()
            {
                return dbset.AsNoTracking().ToList();
            }
            /// <summary>
            /// Fetches records as per the predicate condition
            /// </summary>
            /// <param name="where"></param>
            /// <returns></returns>
            public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
            {
                return dbset.Where(where).ToList();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            public void Detach(T entity)
            {
                dataContext.Entry(entity).State = EntityState.Detached;
            }
            /// <summary>
            /// fetches single records as per the predicate condition
            /// </summary>
            /// <param name="where"></param>
            /// <returns></returns>
            public T Get(Expression<Func<T, bool>> where)
            {
                return dbset.Where(where).FirstOrDefault<T>();
            }
           
        }
