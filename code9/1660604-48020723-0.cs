    ...
    SqlConnection connection = new SqlConnection(sqlConnectionString);
    ServerConnection srvCon = new ServerConnection(connection);
    try
    {
         server = new Server(srvCon);
    
         srvCon.BeginTransaction();
         server.ConnectionContext.ExecuteNonQuery(script);
         srvCon.CommitTransaction();
    }
    catch
    {
         srvCon.RollBackTransaction();
    }
    ...
