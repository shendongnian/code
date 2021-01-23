    Parallel.For(0, 50, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (i) =>
    {
         // surround with try-catch
         string result;
         using (var client = new WebClient()) {
              result = client.DownloadString(string.Format(pageFormat, i));
         }
         // do something with result
         Console.WriteLine("Got a document: {0}", result.Substring(Math.Min(30, result.Length)));
    });
