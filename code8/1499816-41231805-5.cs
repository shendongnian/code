    public class Example
    {
         public ILoggerFactory Factory { get; }
         public Example(ILoggerFactory factory)
         {
              Factory = factory;
         }
    
       
         // Utilize in a method.
         using(var logger = Factory.CreateDbLogger())
              logger.Log(...);
    
         // Utilize in a method.
         using(var logger = Factory.CreateLogger())
              logger.Log(...);
    }
