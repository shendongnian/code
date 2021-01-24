**Database Factory (IDatabaseFactory.cs):** 
    public interface IDatabaseFactory : IDisposable
    {
        Database_DBEntities Get();
    }
**Database Factory Implementations (DatabaseFactory.cs):** 
    
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private Database_DBEntities dataContext;
        public Database_DBEntities Get()
        {
            return dataContext ?? (dataContext = new Database_DBEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
**Base Interface (IRepository.cs):** 
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
**Abstract Class (Repository.cs):**
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
                    throw new ApplicationException(Database_ResourceFile.DuplicateMessage, ex);
                }
                catch (DbUpdateException ex) //DbContext
                {
                    throw new ApplicationException(Database_ResourceFile.DuplicateMessage, ex);
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
**Now the main point is How to access this repository pattern in controller Here we go :**
**1. You have User Model :**
 
    public partial class User
    {
            public int Id { get; set; }
            public string Name { get; set; }
    }
**2. Now you have to create Repository Class of your UserModel**
    public class UserRepository : Repository<User>, IUserRepository
    {
        private Database_DBEntities dataContext;
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
        protected Database_DBEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
      public interface IUserRepository : IRepository<User>
      { 
      }
    }
**3. Now you have to create UserService Interface (IUserService.cs) with all CRUD Methods :**
    public interface IUserService
     {
        
         #region User Details 
         List<User> GetAllUsers();
         int SaveUserDetails(User Usermodel);
         int UpdateUserDetails(User Usermodel);
         int DeleteUserDetails(int Id);
         #endregion
         
    }
**4. Now you have to create UserService Interface (UserService.cs) with all CRUD Methods :**
    public class UserService : IUserService
    {
      IUserRepository _userRepository;
      public UserService() { }
      public UserService(IUserRepository userRepository)
      {
       this._userRepository = userRepository;
      }
      public List<User> GetAllUsers()
      {
          try
          {
              IEnumerable<User> liUser = _userRepository.GetAll();
              return liUser.ToList();
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
       /// <summary>
       /// Saves the User details.
       /// </summary>
       /// <param name="User">The deptmodel.</param>
       /// <returns></returns>
       public int SaveUserDetails(User Usermodel)
       {
           try
           {
               if (Usermodel != null)
               {
                   _userRepository.Add(Usermodel);
                   return 1;
               }
               else
                   return 0;
           }
           catch
           {
               throw;
           }
      
       }
      
       /// <summary>
       /// Updates the User details.
       /// </summary>
       /// <param name="User">The deptmodel.</param>
       /// <returns></returns>
       public int UpdateUserDetails(User Usermodel)
       {
           try
           {
               if (Usermodel != null)
               {
                   _userRepository.Update(Usermodel);
                   return 1;
               }
               else
                   return 0;
           }
           catch
           {
               throw;
           }
       }
      
       /// <summary>
       /// Deletes the User details.
       /// </summary>
       /// <param name="Id">The code identifier.</param>
       /// <returns></returns>
       public int DeleteUserDetails(int Id)
       {
           try
           {
               User Usermodel = _userRepository.GetById(Id);
               if (Usermodel != null)
               {
                   _userRepository.Delete(Usermodel);
                   return 1;
               }
               else
                   return 0;
           }
           catch
           {
               throw;
           }
       }
    	
    }
**5. Now you All set for your Repository Pattern and you can access all data in User Controller :**
    //Here is the User Controller 
    public class UserProfileController : Controller
    {
        
        IUserService _userservice;
    	public CustomerProfileController(IUserService userservice)
        {
            this._userservice = userservice;
    	}
    	
    	[HttpPost]
        public ActionResult GetAllUsers(int id)
        {
    	User objUser=new User();
    	
    	objUser = _userservice.GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
                
    	}
    }
**Cheers !!**
