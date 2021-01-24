    Database db = GetConnectionString();
    string sqlCommand = $"CREATE_RECORD '{escalation.Application}', '{escalation.UpdatedTime}'";
    string idQuery= "Select SCOPE_IDENTITY()"
    int recID = 0;
    using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
    {
        dbCommand.CommandType = commandType.Text;
        db.ExecuteNonQuery(dbCommand);
        dbCommand.CommandText = idQuery;
        recID = (int)dbCommand.ExecuteScalar();
        return recID;
    }
