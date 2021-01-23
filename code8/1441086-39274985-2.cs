    public class DbSomething : IDisposable
    {
        private SqlConnection _connection;
        public DbSomething (SqlConnection connection){
           _connection = connection;
        }
   
    ~DbSomething() {
         Dispose(true);
    }
    bool disposed = false;
    public void Dispose()
    { 
       Dispose(true);
       GC.SuppressFinalize(this);           
    }
    protected virtual void Dispose(bool disposing)
    {
      if (disposed)
         return; 
      if (disposing) 
      {
         _connection.Dispose();
      }
      disposed = true;
     }
    }
