    SqlDataReader reader = null;
        SqlCommand com;
        SqlConnection con = new SqlConnection(@"Data Source=DOTNET;Initial Catalog=edin;Integrated Security=True;Pooling=False");
        com = new SqlCommand("Select name from data where name='" + username + "' and phone='" + password + "'", con);
        con.Open();
        reader = com.ExecuteReader();
        
         
        return reader.HasRows() ? "success" : "error";
        con.Close();
