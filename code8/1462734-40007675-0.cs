    public class CompositeLog : ILog
    {
        private ILog[] logs;
        public ILog[] Logs
        {
            set
            {
                if(logs != null)
                    throw new Exception("The logs dependencies has been set before");
                logs = value;
            }
        }
        public void LogInformation(string message)
        {
            foreach(var log in logs)
                log.LogInformation(message);
        }
        //Other methods here
        //...
    }
