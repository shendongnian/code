    public class RecompileDbCommandInterceptor : IDbCommandInterceptor
    {
        public void ReaderExecuting(DbCommand command,  DbCommandInterceptionContext<DbDataReader> interceptionContext)
    	{
    	    if(!command.CommandText.EndsWith(" option(recompile)"))
    		{
    		    command.CommandText +=  " option(recompile)";
    		}
    	}
    }
