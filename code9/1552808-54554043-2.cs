    public class DataConnection
    {
        public IDbConnection DapperConnection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ToString());
            }
        }
    }
