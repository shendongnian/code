    public void QueryExecution(string SQLQuery, RSDatabaseConnectionCreator connectionCreator)
    {
        using (var conn = connectionCreator.CreateConnection(dbName, true, true)) {
            if (conn != null) {
                ...
            }
        }
    }
