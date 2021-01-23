    var con = _context.Database.GetDbConnection();
    var cmd = con.CreateCommand();
    cmd.CommandType = CommandType.StoredProcedure; 
    cmd.CommandText = "procedures.sp_Users";
    cmd.Parameters.Add(new SqlParameter("@Command", SqlDbType.VarChar) { Value = "Login" } );
    cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar) { Value = "admin" } );
    cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar) { Value = "admin" } );
    
    var retObject = new List<dynamic>();
    con.Open();
    using (var dataReader = cmd.ExecuteReader())
    {
        while (dataReader.Read())
        {
            var dataRow = new ExpandoObject() as IDictionary<string, object>;
            for (var iFiled = 0; iFiled < dataReader.FieldCount; iFiled++)
                dataRow.Add(
                    dataReader.GetName(iFiled),
                    dataReader.IsDBNull(iFiled) ? null : dataReader[iFiled] // use null instead of {}
                );
    
            retObject.Add((ExpandoObject)dataRow);
        }
    }
    return retObject;
