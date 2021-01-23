    namespace ProjectName.Repository
    {
        public class SMRTRepository : IDashboard
        {
            private SqlConnection OpenConnection()
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                return con;
            }
            ....
    
            public IEnumerable<Something>Select(string queryFilter)
            {
                using (SqlConnection cnn = this.OpenConnection())
                {
                    return cnn.Query<Something>(queryFilter);
                }
            }
        }
    }
