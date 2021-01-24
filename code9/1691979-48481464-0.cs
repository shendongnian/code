    public class MyDB
        {
            readonly SQLiteAsyncConnection database;
    
            public MyDB(string dbPath)
            {
                database = new SQLiteAsyncConnection(dbPath);
            }
    
            public async Task CreteMyDb()
            {
                await database.CreateTableAsync<MyObject>();
            }
    
            public async Task<List<MyObject>> GetMyObjectsAsync()
            {
                return await database.Table<MyObject>().ToListAsync();
            }
    
            public async Task<MyObject> GetSingleObjectAsync(int ind)
            {
                return await database.Table<MyObject>().Where(i => i.IndexNumber == ind).FirstOrDefaultAsync();
            }
    
            public async Task<int> SaveMyObjectAsync(MyObject myObject)
            {
                if (myObject.IndexNumber == 0)
                {
                    return await database.InsertAsync(myObject);
                }
                else
                {
                    return await database.UpdateAsync(myObject);
                }
            }
    
            public async Task<int> DeleteMyObjectAsync(MyObject myObject)
            {
                return await database.DeleteAsync(myObject);
            }
        }
