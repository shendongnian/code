    private static  function()
            {
                DataTable dt = new DataTable();
    
                string connectionString = "//your connection string";
    
                
                String strQuery = //"Yourquery";
    
                const int NumberOfRetries = 3;
                var retryCount = NumberOfRetries;
                var success = false;
                while (!success && retryCount > 0)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strQuery;
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 180;
    
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
    
                        
                    catch (Exception ex)
                    {
                        retryCount--;
                        Thread.Sleep(1000 * 60 * 15);
    
                        if (retryCount == 0)
                        {
                           //yourexception
                        }
                    }
                    
                }
               
            }
