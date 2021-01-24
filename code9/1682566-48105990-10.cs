    public class ItemDb
    {
        readonly SQLiteAsyncConnection database;
        readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
    
        public ItemDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
        } 
    
        internal async Task DeleteAllItems()
        {    
            await semaphoreSlim.WaitAsync().ConfigureAwait(false);
            await Initialize<Item>().ConfigureAwait(false);
            
            try
            {
                await database.DropTableAsync<Item>().ConfigureAwait(false);
                await database.CreateTableAsync<Item>().ConfigureAwait(false);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
         
        async Task Initialize<T>()
        {
            if (!DatabaseConnection.TableMappings.Any(x => x.MappedType.Name == typeof(T).Name))
            {
                await DatabaseConnection.EnableWriteAheadLoggingAsync().ConfigureAwait(false);
                await DatabaseConnection.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
            }
        }
    }
