    public class TryCatchHelper
    {
        public Exception Exception { get; private set; } = null;
        
        public void Execute(Action action)
        {
            try
            {
                action()
            }
            catch (Exception e)
            {
                exception = e;
            }
        }
    }
