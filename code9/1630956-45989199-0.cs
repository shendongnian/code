        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");
        //SQL Command
        SqlCommand cmd = new SqlCommand("SELECT password FROM dbo.databasename WHERE username = '" + u +"'"  , conn); 
        //Open connection
        conn.Open();
        //To read from SQL Server
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            recuperatedData = dr["password"].ToString();
        }
        //Close Connections
        dr.Close();
        if (recuperatedData == p)
        {
             //return flag value to shos you've logged in to a different function with post log in functionalities
        } 
} 
