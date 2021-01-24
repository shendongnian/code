    try
    {
        throw new BaseException();
    }
    catch (BaseException e)
    {
        Console.WriteLine(e.GetType());
        MethodA(e);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.GetType());
        MethodA(e);
    }
