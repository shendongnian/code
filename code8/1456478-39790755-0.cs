    public class DALConnection {
        protected string connectionString = "Data Source=RAV-DSK-581;Initial Catalog=HotelMgmt;Integrated Security=True";
        public SqlConnection con;
        public DALConnection(string connectionString) {
            if(connectionString!=null)
                this.connectionString = connectionString;
            con = new SqlConnection(this.connectionString);
        }
    }
