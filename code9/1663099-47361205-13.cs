void TryCatchMethod()
{
    try
    {
       DoSomethingAsync().GetAwaiter().GetResult();
    }
    catch(Exception e)
    {
        //Handle Exception
    }
}
