    public static IDbConnection GetDatabaseConnection(ConnectionType db) 
    {
        switch (db)
        {
            case ConnectionType.DBLocal:
                return new SqlConnection("dblocal connection string here");
                break;
            case ConnectionType.DBRemote:
                return new SqlConnection("db remote connection string here");
                break;
            default:
                throw new InvalidArgumentException("Unrecognized DB Type");
                break;
        }    
    }
