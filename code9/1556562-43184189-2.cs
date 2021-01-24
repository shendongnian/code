    try
    {
        throw new SomeException("It goes wrong here");
        string iNeedThisVariable = "but i never get initialized";
    }
    catch (SomeException e)
    {  
        Console.Out.WriteLine(iNeedThisVariable); //This goes wrong, since you need to show the string, but it has never been initialized
    }
    finally
    {
        Console.Out.WriteLine(iNeedThisVariable); //Also can't use it here!
    }
