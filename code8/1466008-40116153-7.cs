    int num = 70;
    long padovan;
    var timer = new System.Diagnostics.Stopwatch();
    timer.Start(); padovan = GetPadovan(num); timer.Stop();
    Console.WriteLine("for loop method:\t{0,12:F6} ms\tpadovan({1}):{2}", timer.Elapsed.TotalMilliseconds, num, padovan);
    timer.Start(); padovan = GetPadovanRecursive(num); timer.Stop();
    Console.WriteLine("recursive method:\t{0,12:F6} ms\tpadovan({1}):{2}", timer.Elapsed.TotalMilliseconds, num, padovan);
