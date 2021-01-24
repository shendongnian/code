    var conn = new SqlConnection("my connection string");
    var cmd = conn.CreateCommand();
    cmd.CommandText = "dbo.MyProc";
    cmd.CommandType = CommandType.StoredProcedure;
    
    var sqlParam = new SqlParameter("@UserID",
    SqlDbType.UniqueIdentifier);
    sqlParam.Direction = ParameterDirection.Output; 
    
    cmd.Parameters.Add(sqlParam);
    cmd.ExecuteNonQuery();
    // you can now access your output param
    return (Guid)sqlParam.Value;
