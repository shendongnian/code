    Database db = GetConnectionString();
    string sqlCommand = $"CREATE_RECORD '{escalation.Application}', '{escalation.UpdatedTime}'; Select SCOPE_IDENTITY()";
    int recID = 0;
    using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
    {
        dbCommand.CommandType = commandType.Text;
        //TODO: Open connection using your db object
        recID = (int)dbCommand.ExecuteScalar();
        //TODO: Close connection using your db object
        return recID;
    }
