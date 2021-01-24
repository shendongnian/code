Task TryCatchMethod()
{
    try
    {
        return DoSomethingAsync().GetAwaiter().GetResult();
    }
    catch(Exception e)
    {
        //Handle Exception
    }
}
