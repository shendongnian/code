    string query = "SELECT Count(*) as Count FROM Devices";
    SqlCommand cmd = new SqlCommand(query);
    using (SqlConnection con = new SqlConnection(DbConnect.ConnectStr))
    {
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            using (DataSet ds = new DataSet())
            {
                sda.Fill(ds);  
                var count = ds.Tables[0].Rows[0]["Count"].ToString();
                var data = new { Count = count };
                return (new JavaScriptSerializer()).Serialize(data);  
            }
        }
    }
