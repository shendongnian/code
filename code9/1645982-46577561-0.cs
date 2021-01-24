    using (SqlConnection con = new SqlConnection(SQLConnectionString))
    {
        SqlCommand go = new SqlCommand();
        con.Open();
        go.Connection = con;
        go.CommandText = "SELECT InsuredID, FirstName, LastName FROM [Lab2].[dbo].[INSURED]";
        SqlDataReader readIn = go.ExecuteReader();
        while (readIn.Read())
        {
	       // reading data from reader
        }
        con.Close();
        // other stuff
    }
