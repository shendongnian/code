    public class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {
                logger.Log(LogLevel.Error, "Start of the process");
                // Inside Business class i have a lot of other logger.log() calls
                // Inside the business class a have a lot of DAOs that calls logger.log()
                // In ither words, all the calls to logger.log() will be stacked up
                Business b = new Business();
                b.DoSomethig();
                logger.Debug("End of the Process.");
            }
            catch (Exception )
            {
                var target = (MemoryTarget)LogManager.Configuration.FindTargetByName("MemoTarget");
                var logs = target.Logs;
                // Get all the logs in the "stack" of log messages
                foreach (string s in target.Logs)
                {
                    Console.Write("logged: {0}", s);
                }
            }
        }
    }
