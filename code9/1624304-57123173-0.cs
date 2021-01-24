    void Foo() => throw new InvalidOperationException ("foo");
    
    Exception original = null;
    ExceptionDispatchInfo dispatchInfo = null;
    try
    {
        try
        {
            Foo();
        }
        catch (Exception ex)
        {
            original = ex;
            dispatchInfo = ExceptionDispatchInfo.Capture (ex);
            throw ex;
        }
    }
    catch (Exception ex2)
    {
        // ex2 is the same object as ex. But with a mutated StackTrace.
        Console.WriteLine (ex2 == original);  // True
    }
    
    // So now "original" has lost the StackTrace containing "Foo":
    Console.WriteLine (original.StackTrace.Contains ("Foo"));  // False
    
    // But dispatchInfo still has it:
    try
    {
        dispatchInfo.Throw ();
    }
    catch (Exception ex)
    {
        Console.WriteLine (ex.StackTrace.Contains ("Foo"));   // True
    }
