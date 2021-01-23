    bool flagCatch=false;
    try
    {
    
        int a = 10;
        int b = 0;
    
        int c = a / b;
    
        Console.WriteLine(c);
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        //Error handling
        flagCatch=true;
        Console.WriteLine(ex.Message.ToString());
        Console.ReadKey();
    }
    finally
    {
        try
        {
            if(flagCatch)
            { 
                //Code
            }
            else
            {
                //Code when error not comes
            }
        }
        catch(Exception err)
        {
            //Error handling 
        }
    }
