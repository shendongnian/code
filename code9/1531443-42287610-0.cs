    string answer = "";
    string resultCode = "";
    try
    {
        resultCode = "a"; 
    }
    catch
    {
        resultCode = "b";
    }
    finally
    {
        answer = resultCode;
    }
