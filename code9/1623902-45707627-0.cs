    DynamicParameters param = new DynamicParameters();
    
    param.Add("@Fname", tb2.Text, DbType.String, ParameterDirection.Input);
    param.Add("@exist", DbType.Bit, ParameterDirection.ReturnValue);
    con.Execute("DisplayInfo", param, commandType: CommandType.StoredProcedure);
