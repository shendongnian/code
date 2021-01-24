    void Main()
    {
        var test = new Test();
	
        test.Invoke("Method1");
        test.Invoke("Method1Alias");
        try
        {
            test.Invoke("MethodX");
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
        try
        {
            test.Invoke("NonInvokableMethod");
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
