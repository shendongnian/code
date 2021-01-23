    public static SqlConnection getConnection()
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=yourDB;User ID=yourUser;Password=pa$$w0rd");
        return conn;
    }
