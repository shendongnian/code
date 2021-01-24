    public class HomeController : ApiController
    {
        SqlServerConnection conn = new SqlServerConnection();
        internal void Getconnection
        {
            SqlConnection connection = conn.GetConnection();
        }
    }
