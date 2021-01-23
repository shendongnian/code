    public IEnumerable<ResultTableTemplate> GetResultsFromTable(string tableName) {
        using (var context = new MyContext()) {
            var query = context.ExecuteStoreQuery<ResultTableTemplate>("SELECT " +
                "ALL_THOSE_COLUMN_NAMES... " +
                "FROM " + tableName;
    
            return query.ToList();
        }
    }
