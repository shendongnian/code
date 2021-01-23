     public class NewLoggerForEF: DbConfiguration
        {
            public NewLoggerForEF()
            {
                SetDatabaseLogFormatter((context, writeAction) => new   EFCustomLogFormatter(context, writeAction));
            }
        }
