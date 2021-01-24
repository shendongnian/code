`
    // Provide login information
    var crConnectionInfo = new ConnectionInfo();
    // In the form - "SERVER_NAME\\SQLEXPRESS"
    crConnectionInfo.ServerName   = serverName;
    crConnectionInfo.DatabaseName = databaseName;
    if (userID != null)
    {
        crConnectionInfo.UserID   = userID;
        crConnectionInfo.Password = password;
    }
    else
    {
        crConnectionInfo.IntegratedSecurity = true;
    }
`
