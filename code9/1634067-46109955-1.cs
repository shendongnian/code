    using log4net;
    using log4net.Config;
    
    public class MyClass 
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(MyClass));
        
    public void MyMethod()
    {
      try
      {
          //Do something e.g. connect to database
      }
      catch (Exception e)
      {
        log.Info(e.ToString());
      }
    }
    
    }
