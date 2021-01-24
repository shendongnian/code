     public class DataAccess : IDataAccess
        {       
    
            public void CreateCommand(string querystring, string connectionString)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(querystring, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }             
                }
            }
        } 
