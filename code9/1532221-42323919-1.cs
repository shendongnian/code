    //Again this method is within a generic repository so T is defined through the generic repo instantiation
    public async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> taskFunc, [CallerMemberName] string caller = "") {
        try {
            return await taskFunc.Invoke();
        } catch(SQLiteException sqlException) {
            System.Diagnostics.Debug.WriteLine("\nIn GenericRepository.ExecuteSafeAsync() via " + caller + " - Exception attempting to run query on " + typeof(T).Name + "\n" + sqlException.GetBaseException() + "\n");
            if(sqlException.Message.ToLowerInvariant().Contains("column")) {    //The error being searched for is "no such column: <column name>"
                try {
                    await ModelHelpers.UpdateTableSchemaAsync<T>();
                } catch(Exception ex) { //If this fails for what ever reason, we do not want the ModelHelpers.UpdateTableSchemaAsync() method's exception being the one that gets detected upstream
                    System.Diagnostics.Debug.WriteLine("\nIn GenericRepository.ExecuteSafeAsync() via " + caller + " - Exception attempting to run rebuild " + typeof(T).Name + " table after detecting SQLite Exception\n" + ex.GetBaseException() + "\n");
                }
                return await taskFunc.Invoke(); //Now that the table has been recreated lets try to run it again
            }
            throw;
        }
    }
