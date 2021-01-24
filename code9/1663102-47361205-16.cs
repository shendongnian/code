async Task TryCatchMethod()
{
    try
    {
        return await DoSomethingAsync();
    }
    catch(Exception e)
    {
        //Handle Exception
    }
}
