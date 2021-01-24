    public class HomeController : Controller 
    {
        [HttpPost]
        public String HandleValue([FromBody] string inpString) 
        {      
            string sql = "SELECT * FROM Table WHERE (ID = '" + inpString + "')"; 
            SqlConnection connect = new SqlConnection(Connection);
            SqlCommand command = new SqlCommand(sql, connect);
            conn.Open();
            SqlDataReader nwReader = command.ExecuteReader();
            // format and return the results
        }
    }
