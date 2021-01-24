    public async Task DoSomethingAsync(MyRequest request)
    {
        try
        {
             request.result1 = await delegateInstance.Job1(request);
             request.result2 = await delegateInstance.Job2(request);
             Console.Writeline(request.result1 + " " + request.result2);
             return result;
         }
         catch(Exception e)
         {
         }
    }
    public void ICannotBeAsync()
    {
        var task = Task.Run(() => caller.DoSomethingAsync(request);
        // calling the .Result property will block current thread
        Console.WriteLine(task.Result);
    }
