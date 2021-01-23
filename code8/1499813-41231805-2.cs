    public class Example
    {
         public ILoggerFactory Factory { get; }
         public Example(ILoggerFactory factory)
         {
              Factory = factory;
         }
    
         using(var logger = Factory.CreateDbLogger())
              logger.Log(...);
    
         using(var logger = Factory.CreateLogger())
              logger.Log(...);
    }
