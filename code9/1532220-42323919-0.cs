    public static async Task<string> UpdateTableSchemaAsync<T>() where T : class, new() {
        IGenericRepository<T> genericRepo = new GenericRepository<T>();
        try {
            List<T> savedObjects = await genericRepo.AllAsync(); //Collect all current records before dropping table
            if(savedObjects != null && savedObjects.Count > 0) {
                await genericRepo.DropTableAsync();
                await genericRepo.CreateTableAsync();
                // You could do some data transformation here if necessary, such as transferring all Foo.FooId values to the Foo.Id column
                await genericRepo.InsertAllAsync(savedObjects); //Insert all objects back
            } else {
                await genericRepo.DropTableAsync();
                await genericRepo.CreateTableAsync();
            }
            return null;
        } catch(Exception ex) {
            Debug.WriteLine("\nIn ModelHelpers.UpdateTableSchemaAsync() - Exception attempting to recreate " + typeof(T).Name + " data:\n" + ex.GetBaseException() + "\n");
            return "An error occurred while attempting to update the " + typeof(T).Name + " data.";
        }
    }
