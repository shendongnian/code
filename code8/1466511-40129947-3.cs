    var watch = System.Diagnostics.Stopwatch.StartNew();
    var stringArra1y = Enumerable.Repeat(string.Empty, 100000);
    watch.Stop();
    Console.WriteLine(watch.ElapsedTicks); //360
    watch = System.Diagnostics.Stopwatch.StartNew();
    var stringArray2 = new string[100000];
    for (int i = 0; i < stringArray2.Length; i++)
    {
        stringArray2[i] = string.Empty;
    }
    watch.Stop();
    Console.WriteLine(watch.ElapsedTicks); //1335
