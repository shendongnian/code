        try
        {
           // ...
          throw new InvalidOperationException(
             "Arbitrary exception");
           // ...
       }
       catch(System.Web.HttpException exception)
         when(exception.GetHttpCode() == 400)
       {
         // Handle System.Web.HttpException where
         // exception.GetHttpCode() is 400.
       }
       catch (InvalidOperationException exception)
       {
         bool exceptionHandled=false;
         // Handle InvalidOperationException
         // ...
         if(!exceptionHandled)
           // In C# 6.0, replace this with an exception condition
         {
            throw;
         }
        } 
