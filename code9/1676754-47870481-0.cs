    public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
        Console.WriteLine($"Intercepting query ({MethodBase.GetCurrentMethod().Name}): {command?.CommandText ?? "{{no command text}}"}");            
        // dummy empty reader
        interceptionContext.Result = new DataTableReader(new DataTable());
        NotifyMonitor(interceptionContext.DbContexts, command.CommandText);
    }
