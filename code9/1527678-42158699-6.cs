    string result = "";
    cts.CancelAfter(10000);
    Task t = null;
    try
    {
        t = Task.Run(() =>
        {
            using (var stream = new WebClient().OpenRead("http://www.rediffmail.com"))
            {
                cts.Token.ThrowIfCancellationRequested();
                result = "success!";
            }
        }, cts.Token);
        await t;
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine(t.IsCanceled); 
    }
