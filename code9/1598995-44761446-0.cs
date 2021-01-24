    var randomSource =
        Observable.Defer(() => Observable.Timer(TimeSpan.FromSeconds(new Random().NextDouble() * 5))).Repeat().Publish(); 
    
    randomSource
        .Do(v => Console.WriteLine(DateTime.Now))
        .Timeout(TimeSpan.FromSeconds(2)) 
        .Do(_ => { }, err => Console.Write("\t\t\tTimed out\r")) //on error callback
        .Retry()
        .Subscribe(); //set up the pipeline
    
    randomSource.Connect();
    
    Console.ReadLine();
