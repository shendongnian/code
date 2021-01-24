    public static NpgsqlConnection ConnectRemote()
    {
        NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
        sb.ApplicationName = "Connection Tester";
        sb.Host = remoteData.server;
        sb.Port = remoteData.port;
        sb.Username = remoteData.user;
        sb.Password = remoteData.password;
        sb.Database = remoteData.database;
        sb.Pooling = false;
    
        remoteConnection = new NpgsqlConnection(sb.ToString());
    
        try
        {
            remoteConnection.Open();
            NpgSqlCommand test = new NpgSqlCommand("select 1", remoteConnection);
            test.ExecuteScalar();
        }
        catch (NpgsqlException ex)
        {
           throw;
        }
        catch (Exception ex)
        {
           remoteConnection.Close();
           remoteConnection = null;
        }
        return remoteConnection;
    }
