    public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {
        command.CommandText = command.CommandText.Replace("\"\"", "\"").Trim();
        Logger.LogInfo("ReaderExecuted: " +
                       $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}");
    }
