    using (var con = new SqlConnection(connectionstring))
    {
        var cmd = new SqlCommand("dbo.spAddEmployee", con) {
                                    CommandType = CommandType.StoredProcedure};
        con.Open();
        var paramname = new SqlParameter
        {
            ParameterName = "@Name",
            Value = employee.Name
        };
        cmd.Parameters.Add(paramname);
        var paramgender = new SqlParameter
        {
            ParameterName = "@gender",
            Value = employee.Gender
        };
        cmd.Parameters.Add(paramgender);
        var paramcity = new SqlParameter
        {
            ParameterName = "@city",
            Value = employee.City
        };
        cmd.Parameters.Add(paramcity);
        var paramdateofbirth = new SqlParameter
        {
            ParameterName = "@dateofbirth",
            Value = employee.Dateofbirth
        };
        cmd.Parameters.Add(paramdateofbirth);
        cmd.ExecuteNonQuery();
               
    }
