    SqlConnection con = new SqlConnection(strConnString);
                con.Open();
    int js;
    string query= "select Username from register_tab where Email= @username";
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.Add("@username",SqlDbType.VarChar, 50).Value =  
                                               UserName;
    
    using(SqlDataReader reader= cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            js=  reader["Username"].ToString();
        }
    }
    
    con.Close();
    return js;
