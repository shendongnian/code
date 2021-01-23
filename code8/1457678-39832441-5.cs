    var subj = new Subject<int>();
    new Thread(() => {
        Console.WriteLine("thread id - " + Thread.CurrentThread.ManagedThreadId);
        var i = 0;
        while (i < 4)
        {
            i += 1;
            Thread.Sleep(i * 1000);
            subj.OnNext(i);
        }
        subj.OnCompleted();
    }).Start();
    //var timeout = subj.Timeout(TimeSpan.FromSeconds(0.5));
    var timeout = subj.Timeout(TimeSpan.FromSeconds(2));
    IDisposable disp = timeout.Spy().Subscribe(x => Debug.WriteLine("x - " + x), ex => Debug.WriteLine(ex.Message), () => Debug.WriteLine("completed"));
    // That might be missing.
    Thread.CurrentThread.Join(10500);
    disp.Dispose();
