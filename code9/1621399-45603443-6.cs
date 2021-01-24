    using System.Threading.Tasks;
    
    using SQLite;
    
    using Xamarin.Essentials;
    using Xamarin.Forms;
    
    namespace MyNamespace
    {
        public abstract class BaseDatabase
        {
            static readonly string _databasePath = Path.Combine(FileSystem.AppDataDirectory, "SqliteDatabase.db3");
            static readonly Lazy<SQLiteAsyncConnection> _databaseConnectionHolder = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(_databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache));
            SQLiteAsyncConnection DatabaseConnection => _databaseConnectionHolder.Value;
            protected static async Task<SQLiteAsyncConnection> GetDatabaseConnection<T>()
            {
                if (!DatabaseConnection.TableMappings.Any(x => x.MappedType.Name == typeof(T).Name))
                {
                    // On sqlite-net v1.6.0+, enabling write-ahead logging allows for faster database execution
                    // await DatabaseConnection.EnableWriteAheadLoggingAsync().ConfigureAwait(false);
                    await DatabaseConnection.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
                }
                    
                return DatabaseConnection;
            }    
        }
    }
