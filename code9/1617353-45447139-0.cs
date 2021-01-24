    var connstr = new SqlConnectionStringBuilder
    {
        DataSource = "servername",
        IntegratedSecurity = true,
        ApplicationIntent = ApplicationIntent.ReadOnly,
        ApplicationName = "appname",
        InitialCatalog = "db",
        ConnectTimeout = 2
    }.ConnectionString;
    
    using (var conn = new SqlConnection { ConnectionString = connstr })
    {                        
        conn.Open();
    }
