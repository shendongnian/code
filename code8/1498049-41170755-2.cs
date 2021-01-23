        public DataSet GetADataSet()
        {
            DataSet returnDs = null;
            var retryStrategy = new Incremental(3, TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1));
            var retryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(retryStrategy);
            returnDs = retryPolicy.ExecuteAction(() =>
            {
                try
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbc = db.GetStoredProcCommand("dbo.uspGetSomeStuff");
                    DataSet ds;
                    ds = db.ExecuteDataSet(dbc);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
            return returnDs;
        }
