    public class SqlManager
    {
    
        public static string ConnectionString
        {
            get
            {
                return "Your ConnectionString"
            }
        }
    
        public static SqlConnection GetSqlConnection(SqlCommand cmd)
        {
            if (cmd.Connection == null)
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
    
                conn.Open();
    
                cmd.Connection = conn;
    
                return conn;
            }
    
            return cmd.Connection; 
        }
    
        public static object ExecuteScalar(SqlCommand cmd)
        {
            SqlConnection conn = GetSqlConnection(cmd);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch
            {
               throw;
            }
            finally
            {
               conn.Close();
            }
       }
    
    }
