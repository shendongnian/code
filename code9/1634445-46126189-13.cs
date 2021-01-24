    var cmd = new SqlCommand()
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "InsertAList",
            Connection = myConnection
        };
    cmd.Parameters.Add(new SqlParameter("@List", SqlDbType.Structured)
        {
            TypeName = "dbo.MyList",
            Value = table
        });
    cmd.ExecuteNonQuery();
