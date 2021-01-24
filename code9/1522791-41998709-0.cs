    public static IDbConnection CreateConnection()
    {
     switch ((DatabaseProvider.ToUpper()))
     {
     case "DEVARTUNIVERSAL":
        UniConnection uniConnection = new UniConnection();
        return uniConnection; 
               
     case "ACCESS":
        OleDbConnection oleDbConnection = new OleDbConnection();
        return oleDbConnection;
     case "MSQLSERVER2005":
        SqlConnection sqlConnection = new SqlConnection();
        return sqlConnection;
     default:
        throw new Exception("Please select a correct database provider");
        return null;
     }
     }
