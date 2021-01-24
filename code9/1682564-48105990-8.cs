    public class ItemDb
    {
        readonly SQLiteAsyncConnection database;
        readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
    
        bool isInitialized;
    
        public ItemDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
        } 
    
        internal async Task DeleteAll()
        {    
            await semaphoreSlim.WaitAsync().ConfigureAwait(false);
            await Initialize().ConfigureAwait(false);
            
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
         
        async Task Initialize()
        {
            if(isInitialized)
                return;
            
            await database.CreateTableAsync<Item>().ConfigureAwait(false);
    
            isInitialized = true;
        }
    }
