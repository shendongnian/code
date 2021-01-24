    using System.Threading.Tasks;
    
    using SQLite;
    
    using Xamarin.Forms;
    
    namespace MyNamespace
    {
        public abstract class BaseDatabase
        {
            #region Constant Fields
            static readonly Lazy<SQLiteAsyncConnection> _databaseConnectionHolder = new Lazy<SQLiteAsyncConnection>(() => DependencyService.Get<ISQLite>().GetConnection());
            #endregion
    
            #region Fields
            static bool _isInitialized;
            #endregion
            #region Properties
            SQLiteAsyncConnection DatabaseConnection => _databaseConnectionHolder.Value;
            #endregion
    
            #region Methods
            protected static async Task<SQLiteAsyncConnection> GetDatabaseConnectionAsync()
            {
                if (!_isInitialized)
    				await Initialize();
                    
                return DatabaseConnection;
            }
    
            static async Task Initialize()
            {
                await _databaseConnection.CreateTableAsync<OpportunityModel>();
                _isInitialized = true;
            }
            #endregion
    
        }
    }
