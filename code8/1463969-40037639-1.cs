    public BELLogin Login(BELLogin bellog)
    {
        SqlConnection conn = new SqlConnection(connectionsString);
        try
        { 
            using (SqlCommand cmd = new SqlCommand())
            {
               conn.Open();
               cmd.Connection = conn;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "SELECT username,password FROM tbl_login WHERE username = @Username AND password = @Password";
               cmd.Parameters.AddWithValue("@Username", bellog.Acctname);
               cmd.Parameters.AddWithValue("@Password", bellog.Password);
               //really this should be in a using as well. 
               //You be better off reading your data 
               //into a class and returnig the class not the reader.
               using (SqlDataReader dr = cmd.ExecuteReader())
               {
                   BELLogin obj = new BELLogin();
                   while(dr.Read())
                   {
                        //populate obj
                   }
                   return obj;
               }
           }
       }
       finally
       {
           conn.Close();
           conn.Dispose();
       }
    }
