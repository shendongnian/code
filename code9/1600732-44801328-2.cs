    DataTable idRecords = new DataTable();
    // Populate your input table by splitting the emp_id string by ',' and adding each array item to the table 
    SqlCommand cmd = new SqlCommand("sp_GetDataForGraphByEmp", con);
    cmd.CommandType = CommandType.StoredProcedure;
    SqlParameter param = (SqlParameter)sqlClientFactory.CreateParameter();
    param.ParameterName = "@Emp_ID";
    param.SqlDbType = SqlDbType.Structured;
    param.Direction = ParameterDirection.Input;
    param.Value = idRecords;
    cmd.Parameters.Add(param);
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cmd;
    DataTable dt = new DataTable();
    da.Fill(dt);
