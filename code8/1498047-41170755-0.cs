        public DataSet GetADataSet()
        {
            DataSet returnDs = null;
            var retryStrategy = new Incremental(3, TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1));
            var retryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(retryStrategy);
            returnDs = retryPolicy.ExecuteAction(() =>
            {
                try
                {
                    Database db = base.GetDatabase();
                    DbCommand dbc = db.GetStoredProcCommand(PROCEDURE_ORDER_DETAILS_GET_BY_CUSTOMER_XML_SUPERJOIN);
                    DataSet ds;
                    DataTable dt = null;
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
