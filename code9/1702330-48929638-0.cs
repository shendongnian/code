    public class ConnectionContext : IDisposable
    {
        private readonly bool _ContextOwnsConnection;
        public readonly DbConnection Connection;
        public ConnectionContext(DbConnection connection, bool contextOwnsConnection)
        {
            Connection = connection;
            _ContextOwnsConnection = contextOwnsConnection;            
        }
        public void Dispose()
        {
            if(_ContextOwnsConnection)
                Connection.Dispose();
        }
    }
    public abstract class SqliteBase
    {
        public static Func<ConnectionContext> GetContext = _GetConnectionContext;
        private static ConnectionContext _GetConnectionContext()
        {
            return new ConnectionContext(GetConnection(), true);
        }
        private static string _ConnectionString;
        
        protected SqliteBase()
        {
            InitConnectionString();
        }
        public static void InitConnectionString()
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder
            {
                DataSource = ":memory:",
                ForeignKeys = true,
                DefaultTimeout = 3,
                DateTimeKind = DateTimeKind.Utc,
                Pooling = true
            };
            _ConnectionString = builder.ConnectionString;
        }
        public static DbConnection GetConnection()
        {
            try
            {
                DbConnection dbConnection = SQLiteFactory.Instance.CreateConnection();
                dbConnection.ConnectionString = _ConnectionString;
                dbConnection.Open();
                return dbConnection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error opening database connection.", ex);
            }
        }
        /// <summary>
        /// Creates a table in the SQL database if it does not exist
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <param name="columns">Comma separated column names</param>
        protected void CreateTable(string tableName, string columns)
        {
            using (ConnectionContext context = GetContext())
            {
                using (DbCommand dbCommand = context.Connection.CreateCommand($"create table if not exists {tableName} ({columns})"))
                {
                    dbCommand.ExecuteNonQuery();
                }   
            }                   
        }
    }
    public class FooDatabase : SqliteBase
    {
        public FooDatabase()
        {
            Initialize();
        }
        public void Initialize()
        {
            CreateTable("FooTable", "Foo TEXT");
        }
        public void DoFoo()
        {
            using (ConnectionContext context = GetContext())
            {
                using (DbCommand dbCommand = context.Connection.CreateCommand("Select * from FooTable"))
                {
                    dbCommand.ExecuteNonQuery();
                }   
            }                        
        }
    }
