    var watch = System.Diagnostics.Stopwatch.StartNew();
    var stringArra1y = Enumerable.Range(0, 4).Select(i => string.Empty).ToArray();
    watch.Stop();
    Console.WriteLine(watch.ElapsedTicks); //3305
    watch = System.Diagnostics.Stopwatch.StartNew();
    var stringArray2 = new string[4];
    for (int i = 0; i < stringArray2.Length; i++)
    {
        stringArray2[i] = string.Empty;
    }
    watch.Stop();
    Console.WriteLine(watch.ElapsedTicks); //1
