    using log4net;
    
    public class SomeClass
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SomeClass));
    
        public void DoSomething()
        {
            try
            {
                throw new InvalidOperationException("test");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
