    [System.Web.Script.Services.ScriptMethod(), System.Web.Services.WebMethod()]
    public static List<string> SearchClientCode(string prefixText, int count)   
     {
       MySqlConnection conn = new MySqlConnection();
       conn.ConnectionString = ConfigurationManager.ConnectionStrings("conio").ConnectionString;
    MySqlCommand cmd = new MySqlCommand();
    cmd.CommandText = "SELECT clientID, clientName FROM clientsDetails where (clientID like @SearchText)";
    cmd.Parameters.AddWithValue("@SearchText", prefixText + "%");
    cmd.Connection = conn;
    conn.Open();
    List<string> customers = new List<string>();
    MySqlDataReader sdr = cmd.ExecuteReader;
	JavaScriptSerializer serializer = new JavaScriptSerializer();
    while (sdr.Read) {
		object[] item = new object[] { sdr("clientID").ToString(), sdr("clientName").ToString() };
        customers.Add(serializer.Serialize(item));
    }
    conn.Close();
    return customers;}
