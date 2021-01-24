        public class MyDbInterceptor : DbCommandInterceptor
        {
            public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
               
                if (is your table)
                {
                    command.CommandText = "Set Identoty off ,update insert into ,Set Identity off"
                    return;
                }
                base.ReaderExecuting(command, interceptionContext);
              
            }
          
        }
