    //static readonly DatabaseLogger DatabaseLogger = new 
    DatabaseLogger("sqllog.txt", true);
    
           public AutoLotEntities()
                : base("name=AutoLotConnection")
            {
                //DbInterception.Add(new ConsoleWriterInterceptor());
                //DatabaseLogger.StartLogging();
                //DbInterception.Add(DatabaseLogger);
            }
