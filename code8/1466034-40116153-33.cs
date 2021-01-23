    var timer = new System.Diagnostics.Stopwatch(); timer.Stop();
    var padovan = new BigInteger();
    int num = 72;
    
    timer.Restart(); padovan = GetPadovanSlowRecursive(num); timer.Stop();
    Console.WriteLine("GetPadovanSlowRecursive({0}):\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetPadovanRecursive(num); timer.Stop();
    Console.WriteLine("GetPadovanRecursive({0}):\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetPadovanBinomial(num); timer.Stop();
    Console.WriteLine("GetPadovanBinomial({0}):\t\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetPadovanSumCombos(num); timer.Stop();
    Console.WriteLine("GetPadovanSumCombos({0}):\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
    
    timer.Restart(); padovan = GetPadovan(num); timer.Stop();
    Console.WriteLine("GetPadovan({0}):\t\t\t{1}\t{2,12:F6} ms", num, padovan, timer.Elapsed.TotalMilliseconds);
