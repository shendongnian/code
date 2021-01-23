    static int retryCount;
    const int numberOfRetries = 3;
    static void Main(string[] args)
    {
        try
        {
            var theApp = new MyApplicationType(args);
            theApp.StartMyAppLogic();
        }
        catch (ExpectedExceptionType expectThisTypeOfException)
        {
            thisMethodHandlesExceptions(expectThisTypeOfException);
        }
        catch (AnotherExpectedExceptionType alsoExpectThisTypeOfException)
        {
            thisMethodHandlesExceptions(alsoExpectThisTypeOfException);
        }
        catch (Exception unexpectedException)
        {
            if(retryCount < numberOfRetries)
            {
                retryCount++;         
                Main(args);
            }
            else
            {
                throw;
            }
        }
    }
