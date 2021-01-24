    public void SetSqlAuthConnectionString(string server, string db, string user, string pwd)
        {
            // Notice that we are just setting the ConnectionString property.
            ConnectionString =string.Format("Provider=my_oledb_provider;Data Source={0};Initial Catalog={1};User Id={2};Password={3}", server, db, user, pwd
        };
