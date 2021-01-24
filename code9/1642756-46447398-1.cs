    class Program 
    {
       static Logger log = LogManager.GetCurrentClassLogger();
    
       static void Main(string[] args)
       {
          log.Warn(DateTime.Now.ToString("HH:mm:ss.fff MM.dd.yyyy") + " | " + "Testing");
          //How can I check the logging time here?
          // Or if you want to have it after the logger call save it afterwards
          DateTime timeStamp = DateTime.Now;
       }
    }
