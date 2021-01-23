    public virtual DataSet ExecuteDataSet(string storedProcedureName,
                                            params object[] parameterValues)
    {
        using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
        {
            return ExecuteDataSet(command);
        }
    }
