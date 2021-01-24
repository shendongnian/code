        public class DataRepository
	    {
		  private SQLiteAsyncConnection _db;
		  private static readonly AsyncLock Mutex = new AsyncLock();
         
          public async Task CreateDatabaseAsync(string path)
		  {
			using (await Mutex.LockAsync().ConfigureAwait(false))
            {
               _db= new SQLiteAsyncConnection(path);
               await _db.CreateTableAsync<Data>();
               //create other tables
            }
            public async Task Save<T>(T entity) where T : Entity, new()
		    {
			  using (await Mutex.LockAsync().ConfigureAwait(false))
			  {
				await _db.InsertAsync(entity);
			  }
		     }
		     public async Task Delete(Entity item) 
		     {
			   using (await Mutex.LockAsync().ConfigureAwait(false))
			   {
				await _db.DeleteAsync(item);
			   }
		     } 
             
             public async Task Update<T>(T entity) where T : Entity, new()
		     {
			    using (await Mutex.LockAsync().ConfigureAwait(false))
			    {
				  await _db.UpdateAsync(entity);
			    }
		     }           
             ........
             //other base method
          }
