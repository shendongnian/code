      var connectionString = new FbConnectionStringBuilder
      {
        Database = dbPath,
        ServerType = FbServerType.Embedded,
        UserID = "SYSDBA",
        Password = "masterkey",
        ClientLibrary = "fbclient.dll"
      }.ToString();
