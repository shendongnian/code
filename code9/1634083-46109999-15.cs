    void method1()
    {
        try
        {
            method2();
        }
        catch(MyObjectTransferException ex)
        {
              Console.WriteLine(ex.Message);
              Console.WriteLine(ex.ErrorCode);
        }
    }
