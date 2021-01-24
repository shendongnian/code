    public static IDbConnection CreateConnection()
    {
        switch ((DatabaseProvider.ToUpper()))
        {
            case "DEVARTUNIVERSAL":
                return new UniConnection();
            case "ACCESS":
                return new OleDbConnection();
            case "MSQLSERVER2005":
                return new SqlConnection();
            default:
                throw new Exception("Please select a correct database provider");
        }
        return null;
    }
