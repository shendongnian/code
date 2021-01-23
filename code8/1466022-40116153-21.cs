    var timer = new System.Diagnostics.Stopwatch(); timer.Stop();
    var padovan = new BigInteger();
    int num = 72;
    
    timer.Restart(); padovan = GetPadovanSlowRecursive(num); timer.Stop();
    Console.WriteLine("SlowRecursive({0}):\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetPadovanRecursive(num); timer.Stop();
    Console.WriteLine("Recursive({0}):\t\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetSmallPadovan(num); timer.Stop();
    Console.WriteLine("SmallPadovan({0}):\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetPadovan(num); timer.Stop();
    Console.WriteLine("Padovan({0}):\t\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
