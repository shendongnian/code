    public class UnitOfWork<T1, T2> : IUnitOfWork<T1, T2> where T1 : DbContext where T2 : DbContext {
          // FOr DbFactories
          private readonly IDatabaseFactory<T1> _dbFactory1;
          private readonly IDatabaseFactory<T2> _dbFactory2;
        
          //For Seperate DbContexes
          private T _dbContext1;
          private T _dbContext2;
        
          public UnitOfWork () {
            _dbFactory1 = new DatabaseFactory<T1> ();
            _dbFactory2 = new DatabaseFactory<T2> ();
          }
        
          //For Accessiong DbContext Objects in Base Repository
          protected T DbContext1 {
            get { return _dbContext1 ?? (_dbContext1 = _dbFactory1.Init ()); }
          }
          protected T DbContext2 {
            get { return _dbContext2 ?? (_dbContext2 = _dbFactory2.Init ()); }
          }
          public void Commit () {
            DbContext1.SaveChanges ();
            DbContext2.SaveChanges ();
          }
        }
        public interface IUnitOfWork<T1, T2> where T1 : DbContext where T2 : DbContext, IDisposable {
          void Commit ();
        }
    }
