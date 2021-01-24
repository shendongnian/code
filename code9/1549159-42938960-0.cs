    public static void Upgrade(string fileName, string password)
        {
            if (String.IsNullOrEmpty(fileName) || password == null)
                throw new Exception("Unable to create connection string because filename or password was not defined");
            try
            {
                var connectionString = string.Format(@"Data source={0};Password={1}", fileName, password);
                var engine = new SqlCeEngine(connectionString);
                engine.Upgrade();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
