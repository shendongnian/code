    public ODatabase(string hostName, int port, string databaseName, ODatabaseType type, string userName, string userPassword)
    {
        _connectionPool = new ConnectionPool(hostName, port, databaseName, type, userName, userPassword);
        ClientCache = new ConcurrentDictionary<ORID, ODocument>();
    }
