    int num = 72;
    var padovan = new BigInteger();
    
    var timer = new System.Diagnostics.Stopwatch();
    
    timer.Restart(); padovan = GetPadovanSlowRecursive(num); timer.Stop();
    Console.WriteLine("slow recursive:\t{0,12:F6} ms\tpadovan({1}):{2}", timer.Elapsed.TotalMilliseconds, num, padovan);
    
    timer.Restart(); padovan = new BigInteger(GetPadovanRecursive(num)); timer.Stop();
    Console.WriteLine("new recursive:\t{0,12:F6} ms\tpadovan({1}):{2}", timer.Elapsed.TotalMilliseconds, num, padovan);
    
    timer.Restart(); padovan = GetPadovan(num); timer.Stop();
    Console.WriteLine("for looped:\t{0,12:F6} ms\tpadovan({1}):{2}", timer.Elapsed.TotalMilliseconds, num, padovan);
