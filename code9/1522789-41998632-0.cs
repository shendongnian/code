    public static IDbConnection CreateConnection()
    {
        IDbConnection connection;
        switch ((DatabaseProvider.ToUpper()))
        {
            case "DEVARTUNIVERSAL":
                connection = new UniConnection();
                return connection;                
            case "ACCESS":
                connection = new OleDbConnection();
                return connection;
            case "MSQLSERVER2005":
                connection = new SqlConnection();
                return connection;
            default:
                throw new Exception("Please select a correct database provider");
    
        }
        return null;
    }
