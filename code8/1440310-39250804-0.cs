    public class Users
    {        
        public int Id;
        public string FirstName;
    }
    
    public class WebAPIDemoController : ApiController
    {               
        [ActionName("GetUser")]
        [Route("api/WebAPIDemo/GetUserById")]
        [HttpGet]
        public Users GetUserById(int UserId)
        {       
            string connectionstring = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString.ToString();
            MySqlDataReader reader = null;
            MySqlConnection connection;
            using (connection = new MySqlConnection(connectionstring))
            {     
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from User where id='"+ UserId + "' ";
                sqlCmd.Connection = connection;
                connection.Open();
                reader = sqlCmd.ExecuteReader();
                Users usr = new Users();
                while (reader.Read())
                {    
                    usr.FirstName = (Convert.IsDBNull(reader["FirstName"]) ? "" : Convert.ToString(reader["FirstName"]));
                    connection.Close();
                }
                return usr;                                     
            }    
        }   
    }
