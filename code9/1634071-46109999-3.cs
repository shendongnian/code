    void method1()
    {
        try
        {
            method2();
        }
        catch(Exception ex)
        {
              Console.WriteLine(ex.Message);
        }
    }
