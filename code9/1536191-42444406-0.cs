    public class NullCrmTracingService : ITracingService
    {
        public void Trace(string format, params object[] args)
        {
            //do nothing
        }
    }
