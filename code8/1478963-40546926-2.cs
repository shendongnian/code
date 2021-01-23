     public void TestOracleConnection()
        {
            using (var dbContext = new UCAS_dbContext())
            {
                var query = (from b in dbContext.SyncCodes
                             select b).ToList();
            }
        }
