    var tasks = new List<Task>();
    foreach (var message in messages)
    {
        tasks.Add(Task.Run(() => _mailService.SendEmail(message)));
    }
    Task waiter = Task.WhenAll(tasks);
    try
    {
       waiter.Wait();
    }
    catch {}   
    if (waiter.Status == TaskStatus.RanToCompletion)
    {
        Console.WriteLine("All messages sent.");
    }
    else
    {
        Console.WriteLine("Some messages failed to send.");  
    }
