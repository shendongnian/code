    public void cnOpen()
            {
                try
                {
                    if (Conn == null)
                    {
                        Conn = new System.Data.SqlClient.SqlConnection();
                    }
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                    Conn.ConnectionString = ConnectionString;
                    Conn.Open();
                }`
