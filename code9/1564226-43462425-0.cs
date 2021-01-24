    class EFCommandInterceptor: IDbCommandInterceptor
    {
        public void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
    
        public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync,  command.CommandText));
        }
    
        public void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContextt<System.Data.Common.DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
    
        public void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
    
        public void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
    
        public void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }
    
        private void LogInfo(string command, string commandText)
        {
            Console.WriteLine("Intercepted on: {0} :- {1} ", command, commandText);
        }
    } 
