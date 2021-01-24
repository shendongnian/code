    public void Close()
    {
        if (connection != null && connection.State != ConnectionState.Closed)
        {
            connection.Close();
        }
    }
