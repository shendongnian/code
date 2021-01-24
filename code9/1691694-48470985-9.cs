    public class MyLoggingModel : DbContext, IMyLoggingModel {
        public MyLoggingModel(DbConnectionInfo connection)
            : base(connection.ConnectionString) {
        }
    
        public virtual DbSet<Log> Log { get; set; }
        //...
    }
