    public bool OpenDatabase()
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }
