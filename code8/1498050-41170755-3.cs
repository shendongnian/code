        public void DoSomething()
        {
            RetryStrategy retryStrat = new Incremental(3, TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1));
            RetryPolicy retryPol = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(retryStrat);
            int myValue = retryPol.ExecuteAction(() =>
            {
                try
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbc = db.GetStoredProcCommand("dbo.uspDoSomething");
                    return db.ExecuteNonQuery(dbc); /* because this returns an int, ExecuteAction return will also be an int */
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
