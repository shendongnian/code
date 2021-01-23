    Parallel.For(0, 50, new ParallelOptions() { MaxDegreeOfParallelism = 5 },  
    (i) =>
    {
        // surround with try-catch
        var watch = Stopwatch.StartNew();
        string result;
        using (var client = new WebClient()) {
             result = client.DownloadString(string.Format(pageFormat, i));
        }
        // do something with result
        Console.WriteLine("Got a document: {0}", result.Substring(Math.Min(30, result.Length)));
        watch.Stop();
        var sleep = 2000 - watch.ElapsedMilliseconds;
        if (sleep > 0)
              Thread.Sleep((int)sleep);
    });
