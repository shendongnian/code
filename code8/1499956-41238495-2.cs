      // Please, notice: the same string for both ToUpper/ToLower
      string GiniPig = string.Concat(Enumerable
        .Range(1, 1000000) // a million chunks "my test/MyTest" combined
        .Select(item => "my test/MY TEST"));
    
       Stopwatch sw = new Stopwatch();
    
       // Let's try n (100) times 
       int n = 100;
    
       var sampling = Enumerable
         .Range(1, n)
         .Select(x => {
            sw.Reset();
            sw.Start();
    
            GiniPig.ToLower(); // change this into .ToUpper();
    
            sw.Stop();
            return sw.ElapsedMilliseconds; })
         .ToSampling(x => x); // Side library; by you may save the data and analyze it with R
    
       Console.Write(
         $"N = {n}; mean = {sampling.Mean:F0}; std err = {sampling.StandardDeviation:F0}");
