    public class DateInterceptor : IDbInterceptor, IDbCommandInterceptor
    {
        public void ReaderExecuting(DbCommand command, 
            DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var dateParameters = command.Parameters.OfType<DbParameter>()
                .Where(p => p.DbType == DbType.DateTime2);
            foreach (var parameter in dateParameters)
            {
                parameter.DbType = DbType.DateTime;
            }
        }
