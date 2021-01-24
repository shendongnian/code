    using (SqlConnection con = new SqlConnection("Data Source=ipaddress;Initial Catalog=database;User ID=userid;Password=password;")) {
        con.Open();
        using (SqlCommand cmd = con.CreateCommand()) {
            cmd.CommandText = "web.sp_getTotalBillPayam";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
            //repeat this for each parameter
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = "PhoneNumber";    //this must match whatever your parameters are to your stored proc
            parameter.DbType = System.Data.DbType.Int64;
            parameter.Direction = System.Data.ParameterDirection.Input;
            parameter.Value = phoneNumber;
            cmd.Parameters.Add(parameter);
    
            ...
            //if you have an OUTPUT result from your proc, add a a parameter called RETURNS with a direction of ParameterDirection.Return and check value AFTER executing
    
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                //if your results are a SELECT query they will be here
            }
    
        }
    }
