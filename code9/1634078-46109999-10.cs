    void method1()
    {
        try
        {
            method2();
        }
        catch(MyObjectTransferExceptionex)
        {
              Console.WriteLine(ex.Message);
              Console.WriteLine(ex.ErrorCode);
        }
    }
