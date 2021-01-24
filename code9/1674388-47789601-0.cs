     public class StringInterceptor : IDbCommandInterceptor
        {
            public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
                foreach (var p in command.Parameters.Cast<DbParameter>())
                {
                    if (p.Value is string)
                    {
                        if (((string)p.Value) == string.Empty)
                        {
                            p.Value = " ";
                        }
                    }
                   
                }
    
            }
