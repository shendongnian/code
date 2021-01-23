        if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
        if (Conn == null)
                    {
                        Conn = new System.Data.SqlClient.SqlConnection();
                        Conn.ConnectionString = ConnectionString;
                       
                   
                    }
