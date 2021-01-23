    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sql = System.Configuration.ConfigurationManager.ConnectionStrings["EventDBConnectionString"].ConnectionString;
    
                var connection = new SqlConnection(sql);
    
                var commandString = " SELECT * FROM Event WHERE EventID = @eventID ";
    
                var eventID = -1;
    
                try
                {
                    eventID = Convert.ToInt32(Request.QueryString["id"]);
                }
                catch
                {
                    eventID = -1;
                }
    
                var command = new SqlCommand(commandString, connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("@eventID", eventID));
                command.Connection.Open();
                command.ExecuteNonQuery();
    
                var html = "<table><tr><td>Name</td><td>Type</td><td>NumTickets</td><td>EventDate</td><td>ShortDescription</td><td>ImageLocation</td></tr>";
    
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
    
                if (reader.HasRows)
                {
                    reader.Read();
    
                    // display values in controls
    
                    movieString.InnerHtml = html;
                }
    
                command.Connection.Close();
                command.Dispose();
    
                connection.Dispose();
            }
        }
    }
