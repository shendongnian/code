    public class MyAdoNetAppender : AdoNetAppender
    {
        override protected void SendBuffer(IDbTransaction dbTran, LoggingEvent[] events)
        {
            (... implementation goes here)
        }
    }
