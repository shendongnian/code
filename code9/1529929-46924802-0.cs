    string connectionString = "Server=Ip;User Id=user;Password=123456;database=dev";
    System.Data.SqlClient.SqlConnectionStringBuilder scsb = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
    scsb.Pooling = true;
    
    EntityConnectionStringBuilder csb = new EntityConnectionStringBuilder();
    csb.ProviderConnectionString = scsb.ConnectionString; 
    csb.Provider = "MySql.Data.MySqlClient";
    return csb.ConnectionString; 
