    ....
    DataSet result = reader.AsDataSet();
    string cmdText = @"insert into SalesRepresentative
        (@country,@state,@city,@name,@pno)";
    // using statement around disposable objects.....
    using(SqlConnection connection= new SqlConnection(....))
    using(SqlCommand cmd = new SqlCommand(cmdText, connection))
    {
        connection.Open();
        // Add all parameters before entering the insert loop        
        cmd.Parameters.Add("@country", SqlDbType.NVarChar);
        cmd.Parameters.Add("@state", SqlDbType.NVarChar);
        cmd.Parameters.Add("@city", SqlDbType.NVarChar);
        cmd.Parameters.Add("@name", SqlDbType.NVarChar);
        cmd.Parameters.Add("@pno", SqlDbType.NVarChar);
       
        for (i = 0; i < result.Tables[0].Rows.Count; i++)
        {
            country = result.Tables[0].Rows[i].ItemArray[0].ToString();
            state = result.Tables[0].Rows[i].ItemArray[1].ToString();
            city =result.Tables[0].Rows[i].ItemArray[2].ToString();
            name = result.Tables[0].Rows[i].ItemArray[3].ToString();
            pno = result.Tables[0].Rows[i].ItemArray[4].ToString();
            // Set the parameter values 
            cmd.Parameters["@country"].Value = country;
            cmd.Parameters["@state"].Value = state;
            cmd.Parameters["@city"].Value = city ;
            cmd.Parameters["@name"].Value = name;
            cmd.Parameters["@pno"].Value = pno;
            // No need of an SqlDataAdapter here, just execute the command...
            cmd.ExecuteNonQuery();
       }
    }
    return View(result.Tables[0]);
