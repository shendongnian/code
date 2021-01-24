    void DoSomething(System.Threading.CancellationToken tok)
    {
        Thread.Sleep(900);
        if (tok.IsCancellationRequested)
            return;
        Console.WriteLine("after 1");
        Thread.Sleep(1800);
        if (tok.IsCancellationRequested)
            return;
        Console.WriteLine("after 2");
    
    }
    void Main()
    {
        try
        {
            var cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            System.Threading.Tasks.Task.Run(() =>
            {
               DoSomething(ct);
              //DoSomething(); excute long time   
          });
            System.Threading.Tasks.Task.Run(() =>
            {
                Thread.Sleep(1000);
               cts.Cancel();
            }).Wait();
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("exception" + ex.Message);
        }
        finally
        {
            Console.WriteLine("finally");
        }
    }
