    var codesParameter = new SqlParameter
    {
        ParameterName = "@fcodes",
        SqlDbType = SqlDbType.Structure,
        TypeName = "dbo.FCodes", // Important! - name of type in database
        Value = dataTableOfCodes // Should contain column with name "Code"
    };
    using (var connection = new SqlConnection(connectionString)) 
    using (var command = connection.CreateCommand()) 
    {
        command.CommandText = "dbo.AProc_Getback";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(codesParameter);
        connection.Open();
        command.ExecuteNonQuery();
    }
