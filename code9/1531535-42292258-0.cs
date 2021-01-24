    private static string _connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ToString();
    public static IMongoDatabase GetDatabase()
    {
        var _databaseName = MongoUrl.Create(_connectionString).DatabaseName;
        return new MongoClient(_connectionString).GetDatabase(_databaseName);
    }
