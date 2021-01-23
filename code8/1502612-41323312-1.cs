    namespace MyNamespace
    {
        using NLog;
        public class MyClass
        {
           private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    
           public void Method()
           {
               Logger.Error("My error message");
           }
         }
    }
