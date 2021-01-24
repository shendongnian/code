    public class NLogCommandInterceptor : IDbCommandInterceptor 
    { 
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger(); 
 
        public void NonQueryExecuting( 
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext) 
        { 
            LogIfNonAsync(command, interceptionContext); 
        } 
 
        public void NonQueryExecuted( 
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext) 
        { 
            LogIfError(command, interceptionContext); 
        } 
 
        public void ReaderExecuting( 
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) 
        { 
            LogIfNonAsync(command, interceptionContext); 
        } 
 
        public void ReaderExecuted( 
            DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) 
        { 
            LogIfError(command, interceptionContext); 
        } 
 
        public void ScalarExecuting( 
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext) 
        { 
            LogIfNonAsync(command, interceptionContext); 
        } 
 
        public void ScalarExecuted( 
            DbCommand command, DbCommandInterceptionContext<object> interceptionContext) 
        { 
            LogIfError(command, interceptionContext); 
        } 
 
        private void LogIfNonAsync<TResult>( 
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext) 
        { 
            if (!interceptionContext.IsAsync) 
            { 
                Logger.Warn("Non-async command used: {0}", command.CommandText); 
            } 
        } 
 
        private void LogIfError<TResult>( 
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext) 
        { 
            if (interceptionContext.Exception != null) 
            { 
                Logger.Error("Command {0} failed with exception {1}", 
                    command.CommandText, interceptionContext.Exception); 
            } 
        } 
    }
