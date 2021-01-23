    class EFCustomLogFormatter:: DatabaseLogFormatter
    { 
        public EFCustomLogFormatter(DbContext context, Action<string>  writeAction): base(context, writeAction)
        {
            
        }
        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
           //process your command and text
           Write(processedCommand);
        }
     }
       
