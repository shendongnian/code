    public class OptionRecompileHintDbCommandInterceptor : IDbCommandInterceptor
    {
    
    
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            addQueryHint(command);
        }
    
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            addQueryHint(command);
        }
    
        private static void addQueryHint(IDbCommand command)
        {
            if (command.CommandType != CommandType.Text || !(command is SqlCommand))
                return;
    
            if (command.CommandText.StartsWith("select", StringComparison.OrdinalIgnoreCase) && !command.CommandText.Contains("option(recompile)"))
            {
                command.CommandText = command.CommandText + " option(recompile)";
            }
        }
    }
