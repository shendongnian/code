    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = System.Configuration.ConfigurationManager.ConnectionStrings["EventDBConnectionString"].ConnectionString;
                
                var connection = new SqlConnection(sql);
                
                var commandString = " SELECT * FROM Event ";
                
                var Command = new SqlCommand(commandString, connection);
                Command.CommandType = CommandType.Text;
                Command.Connection = connection;
                Command.Connection.Open();
                Command.ExecuteNonQuery();
    
                var html = "<table><tr><td>Name</td><td>Type</td><td>NumTickets</td><td>EventDate</td><td>ShortDescription</td><td>ImageLocation</td></tr>";
    
                var Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
    
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        html += "<tr><td>" + Reader["Name"] + "</td>";
                        html += "<td>" + Reader["Type"] + "</td>";
                        html += "<td>" + Reader["NumTickets"] + "</td>";
                        html += "<td>" + Reader["EventDate"] + "</td>";
                        html += "<td>" + Reader["ShortDescription"] + " <a href='Events.aspx?id=" + Reader["EventID"] + "'> More</a>" + "</td>";
                        html += "<td><img src='App_Media\\" + Reader["ImageLocation"] + "'>" + "</td><tr>";
                    }
    
                    html += "</table>";
    
                    movieString.InnerHtml = html;
                }
    
                Command.Connection.Close();
                Command.Dispose();
    
                connection.Dispose();
            }
        }
    }
