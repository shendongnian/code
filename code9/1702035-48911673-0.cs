    public SqlConnection SetConnection()
    {
        SqlConnection myConnection = new SqlConnection("user id=[username];" +
                                                "password=[password];" +
                                                "server=[server];" +
                                                "database=[db_name];");
        try
        {
            myConnection.Open();
        }
        catch(Exception e)
        {
            Console.WriteLine("Unable to Connect");
        }
        return myConnection;
    }
