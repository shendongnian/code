    try
    {
        throw new BaseException();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.GetType());
        MethodA(e);
    }
