    var query = "SELECT Id, UserName, List_Order, LoggedIn " + 
                "FROM AspNetUsers" +
                "WHERE LoggedIn = 1" + 
                "ORDER BY List_Order ASC";
    
    var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    var cmd = new SqlCommand(query, conn);   
    conn.Open();
    var rdr = cmd.ExecuteReader();
    ViewBag.speakers = new List<string[]>();
    while(rdr.Read())
    {
        if (Convert.ToString(rdr["UserName"]) != null)
        {
            var speakers = new string[4] {
                Convert.ToString(rdr["Id"]),
                Convert.ToString(rdr["UserName"]),
                Convert.ToString(rdr["List_Order"]),
                Convert.ToString(rdr["LoggedIn"]) 
            };
            ViewBag.speakers.Add(speakers);
        }
    }
