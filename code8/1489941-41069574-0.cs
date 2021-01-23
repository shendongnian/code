    public class ChangeTrackingInterceptor : IDbCommandInterceptor
    {
        private byte[] GetChangeTrackingContext()
        {
            // TODO: Return the appropriate change tracking context data
            return new byte[] { 0, 1, 2, 3 };
        }
    
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            command.CommandText = "WITH CHANGE_TRACKING_CONTEXT (@change_tracking_context)\r\n" + command.CommandText;
    
            // Create the varbinary(128) parameter
            var parameter = command.CreateParameter();
            parameter.DbType = DbType.Binary;
            parameter.Size = 128;
            parameter.ParameterName = "@change_tracking_context";
            parameter.Value = GetChangeTrackingContext();
            command.Parameters.Add(parameter);
        }
    
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
        }
    
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }
    
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
        }
    
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
        }
    }
