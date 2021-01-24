    public void Connect()
    {
        string connectionStr = string.Empty;
        try
        {
            if(CheckConnection(Properties.Settings.Default.MyLiveConnectionString))
                connectionStr = Properties.Settings.Default.MyLiveConnectionString;
        }
        catch (Exception ex)
        {
            //Log this, etc...
        }
    
        if (string.IsNullOrWhiteSpace(connectionStr))
            connectionStr = Properties.Settings.Default.MyLocalConnectionString;
    
        using (SqlConnection con = new SqlConnection(connectionStr))
        {
            //Voila!
        }
    }
    
    private static bool CheckConnection(string connectionString)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
    
            SqlCommand cmd = new SqlCommand("SELECT 1", conn);
            conn.Open();
            if ((int)cmd.ExecuteScalar() == 1)
                return true;
        }
    
        return false;
    }
