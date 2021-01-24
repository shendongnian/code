    public static void AssignConnection()
    {
        string MyConString = "SERVER=localhost;" +
        "DATABASE=test;" +
        "UID=root;" +
        "PASSWORD=;" +
        "SSL Mode=None;" +
        "charset=utf8";
    
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
    }
