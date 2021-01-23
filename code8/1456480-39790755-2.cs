    public class DALConnection {
        protected string connectionString = "Data Source=ABC;Initial Catalog=HotelMgmt;Integrated Security=True";
        public SqlConnection con;
        public DALConnection(string connectionString) {
            if(connectionString!=null)
                this.connectionString = connectionString;
            con = new SqlConnection(this.connectionString);
        }
    }
