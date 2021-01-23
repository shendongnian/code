    var query = "SELECT Id, UserName, List_Order, LoggedIn " + 
                "FROM AspNetUsers" +
                "WHERE LoggedIn = 1" + 
                "ORDER BY List_Order ASC";
    
    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
    {
        using (var cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            var dt = new DataTable();
            ViewBag.speakers = new List<string[]>();
            var rdr = cmd.ExecuteReader();
    	    dt.Load(rdr);
    
    	    for (int n = 0; n < dt.Rows.Count; n++)
            {
        	    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[n]["UserName"])))
                {
                    // speakers returns String[4] array instead of null value
                    var speakers = new String[4] {
    	                Convert.ToString(dt.Rows[n]["Id"]),
    	                Convert.ToString(dt.Rows[n]["UserName"]),
    	                Convert.ToString(dt.Rows[n]["List_Order"]),
    	                Convert.ToString(dt.Rows[n]["LoggedIn"])
                    };
                    ViewBag.speakers.Add(speakers);
                }
            }
            conn.Close();
        }
    }
