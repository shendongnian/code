    public abstract class BaseRepository<T1,T2,T> : IUnitOfWork<T1, T2> where T : class where T1 : DbContext where T2 : DbContext {
      #region Properties
      // private DbContext _dataContext1; //for first DbContext
      // private DbContext _dataContext1; //for second DbContext
      private readonly IDbSet<T> _dbSet1; //Going to Perform Operations using Dbsets
      private readonly IDbSet<T> _dbSet2;
    
    //For Exposing DbContext to respective Implementing Repositories This is Optional
      protected DbContext DataContext1 {
        get { return DbContext1; } //retuning DbCOntext Object Created in UOW class
      }
      protected DbContext DataContext2 {
        get { return DbContext2; }
      }
    
      //For Exposing DbSets to respective Implementing Repositories This is Optional
      protected IDbSet<T> DbSet1 => _dbSet1;
      protected IDbSet<T> DbSet2 => _dbSet2;
    
      protected BaseRepository () {
        _dbSet1 = DataContext1.Set<T> ();
        //OR
        _dbSet2 = DataContext2.Set<T> ();
      }
      #endregion
    
      #region Implementation
    
      #endregion
    }
    
