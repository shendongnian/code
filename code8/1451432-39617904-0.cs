    static int retryCount;
    const int numberOfRetries = 3;
    static void Main(string[] args)
    {
       try
       {
          var theApp = new MyApplicationType(args);
          theApp.StartMyAppLogic();
       }
       catch (ExpectExceptionType expectThisTypeOfException)
       {
            thisMethodHandlesExceptions(expectThisTypeOfException);
       }
       catch (AnotherExpectedExceptionType alsoExpectThisTypeOfExcpetion)
       {
           thisMethodHandlesExceptions(alsoExpectThisTypeOfExcpetion);
       }
       catch (Exception unexpectedException)
       {
           if(retryCount < numberOfRetries)
           {
                retry++;         
                Main(args);
           }
           else
           {
                throw;
           }
       }
    
    }
