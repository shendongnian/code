    try
    {
        _transaction = _connection.BeginTransaction("UpdateTransaction");
        command.Transaction = _transaction;
    
        while (reader.Read())
        {
            var extId = reader.GetValue(indexOfColumn3).ToString();
            string finalId = "Something new...";
            UpdateIdSqlTransaction(extId, finalId);
        }
        _transaction.Commit();
    }
    catch (Exception)
    {
         _transaction.Rollback();
    }
