    try
    {
        var task = Task.Run(() => rpcClient.Call(data_encoded));
        if (task.Wait(TimeSpan.FromSeconds(3)))
        {
            response = task.Result;
        }
        else
        {
            throw new Exception("Timed out");
        }
        Console.WriteLine("RESPONSE : " + response);
    }
    catch (Exception e)
    {
        // Some code here ...
    }
