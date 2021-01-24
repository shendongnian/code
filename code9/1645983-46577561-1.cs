    using (SqlConnection con = new SqlConnection(SQLConnectionString))
    {
        System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();
        con.Open();
        go.Connection = con;
        go.CommandText = "SELECT InsuredID, FirstName, LastName FROM [Lab2].[dbo].[INSURED] WHERE InsuredID = @InsuredID";
        go.Parameters.Add("@InsuredID", SqlDbType.Int).Value = 1; // example value for parameter passing
        SqlDataReader readIn = go.ExecuteReader();
        while (readIn.Read())
        {
	       // reading data from reader
        }
        con.Close();
        // other stuff
    }
