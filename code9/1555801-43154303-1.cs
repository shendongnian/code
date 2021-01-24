    StringBuilder sb = new StringBuilder(string.Empty);
    List<SqlParameter> prms = new List<SqlParameter>();
    string[] splitItems = null;
    // Base string for creating parameter placeholders dynamically
    string sqlStatement = "INSERT INTO Ingredients_List (Ingredients1) VALUES (@p{0});";
    int count = 1;
    foreach (string item in sc)
    {
        if (item.Contains(","))
        {
            splitItems = item.Split(',');
            // Parameter name created dynamically
            prms.Add(new SqlParameter($"@p{count}", SqlDbType.NVarChar) {Value=splitItems[0]});
            // Create the placeholder for the nth parameter
            sb.AppendFormat(sqlStatement, count);
        }
    }
    // Don't execute anything if there are no parameters (or stringbuilder empty)
    if(prms.Count > 0)
    {
        using (SqlConnection connn = new SqlConnection(GetConnectionString()))
        using (SqlCommand cmd = new SqlCommand(sb.ToString(), connn))
        {
            connn.Open();
            // Add all parameters together
            cmd.Parameters.AddRange(prms);
            cmd.ExecuteNonQuery();
        }
    }
