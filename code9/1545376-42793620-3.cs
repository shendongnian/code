            public MyDBContext (string connectionName)
                : base(connectionName)
            {
                
                Configuration.AutoDetectChangesEnabled = false;
                Configuration.LazyLoadingEnabled = false;
                Configuration.ProxyCreationEnabled = false;
                Database.CommandTimeout = 300;
                Database.Log = sql => Debug.WriteLine(sql);
    
                SetIsolationLevel("READ UNCOMMITTED");
            }
    
            private void SetIsolationLevel(string isolationLevel = null)
            {
                if (isolationLevel == null)
                    isolationLevel = TransactionUtils.IsolationLevelString;
    
                if (!string.IsNullOrEmpty(isolationLevel))
                {
                    Database.ExecuteSqlCommand($"SET TRANSACTION ISOLATION LEVEL {isolationLevel};");
                }
            }
