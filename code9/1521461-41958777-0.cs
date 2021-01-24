    public int LoggedinUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionInfo))
            {
                using (SqlCommand cmd = new SqlCommand("LoggedinUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open(); 
                    int result = cmd.ExecuteScalar();
                    conn.Close();
                } 
                conn.Dispose(); 
            }
            return result;
        }
