    public class Database
    {
        public string DoSomething()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID,Name From Person", con))
                {
                    //note: using a using here as well
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            //this is ok, because the USING will take care of the disposure.
                            return reader["Name"].ToString();
                        }
                    }
                }
            }
        }
    }
