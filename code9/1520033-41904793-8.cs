    using (var con = new SqlConnection(connectionString))
    {
        bool exists = false;
        using(var cmd = new SqlCommand("SELECT TOP 1 1 FROM ResultsTable WHERE TagNumber=@TagNumber AND [Date]=@Date", con))
        {
            cmd.Parameters.AddWithValue("@TagNumber", tagNumber);
            cmd.Parameters.AddWithValue("@Date", date.Date);
    
            con.Open();
            var result = cmd.ExecuteScalar(); //returns object null if it doesnt exist
            con.Close();
    
            exists = result != null; //result will be one or null.
        }
        if (exists)
        {
            //INSERT RECORD
        }
    }
