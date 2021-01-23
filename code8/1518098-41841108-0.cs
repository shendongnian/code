    Task parent = null;
    var antecedent = new Task(() =>
    {
        Console.WriteLine("Antecedent begun");
        Thread.Sleep(1000);
    }, new CancellationToken(), TaskCreationOptions.AttachedToParent);
    antecedent.Start();
    parent = new Task(() =>
        {
            Console.WriteLine("Parent begun");
            Thread.Sleep(500);
            Task.Factory.ContinueWhenAll(new[] { antecedent }, _ =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("parent status: {0}", parent.Status);
            });
        });
    parent.Start();
    parent.Wait();
