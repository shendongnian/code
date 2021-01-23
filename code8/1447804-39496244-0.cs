    Try
    {
        //Your try code Here
        if(/*Something Happens*/)
        {
           throw new YourCustomExceptionClass("Message");
        }
        else
        {
           throw new AnotherCustomExceptionClass("Other Message");
        }
    }
    Catch(YourCustomExceptionClass err)
    {
       //This will be a type of exception
    }
    Catch(AnotherCustomExceptionClass err)
    {
       //This will be another type of Exception
    }
