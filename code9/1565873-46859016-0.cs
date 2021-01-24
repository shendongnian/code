    ManagementObjectSearcher searcher = new ManagementObjectSearcher();
    var wmiQry =
        "SELECT * "
        + "FROM   Win32_PnPSignedDriver "
        + "WHERE  "
        + @"         ClassGuid    = '{4d36e978-e325-11ce-bfc1-08002be10318}' "
        + @" and     DeviceID  LIKE 'BTHENUM%' "
        + @" and NOT DeviceID  LIKE '%&000000000000_%' "
        + @" and     InfName      = 'bthspp.inf' ";
    searcher.Scope = new ManagementScope(@"root\CIMV2");
    searcher.Query = new WqlObjectQuery(wmiQry);
    ManagementObjectCollection queryResults;
    Stopwatch stopWatch = new Stopwatch();
    long responseTime;
    // Time to execute the query.
    stopWatch.Start();
    queryResults = searcher.Get();
    stopWatch.Stop();
    responseTime = stopWatch.ElapsedMilliseconds;
    stopWatch.Reset(); // clear the timer before it is used again
    Console.WriteLine(responseTime + " ms.  Time to perform searcher.Get() query");
    // Time to perform a foreach loop over the collection.
    Stopwatch loopStopwatch = new Stopwatch();
    loopStopwatch.Reset();
    loopStopwatch.Start();
    foreach (ManagementBaseObject device in queryResults) { }
    loopStopwatch.Stop();
    long loopTime = loopStopwatch.ElapsedMilliseconds;
    loopStopwatch.Reset();
    Console.WriteLine(loopTime + " ms. Time to perform Empty foreach over ManagementObjectCollection");
    // Time to Copy collection to an array  
    ManagementObject[] deviceArray = new ManagementObject[queryResults.Count];
    loopStopwatch.Reset();
    loopStopwatch.Start();
    queryResults.CopyTo(deviceArray, 0);
    loopStopwatch.Stop();
    loopTime = loopStopwatch.ElapsedMilliseconds;
    loopStopwatch.Reset();
    Console.WriteLine(loopTime + " ms.  Time to perform queryResults.CopyTo array");
    // Time to loop through array of ManagementObject s
    loopStopwatch.Reset();
    loopStopwatch.Start();
    foreach (var btDevice in deviceArray)
    {
        var deviceID = btDevice["DeviceID"].ToString();
        var devName = btDevice["FriendlyName"].ToString();
    }
    loopStopwatch.Stop();
    loopTime = loopStopwatch.ElapsedMilliseconds;
    loopStopwatch.Reset();
    Console.WriteLine(loopTime + " ms.  Time to perform foreach array");
    // Time to perform alternate loop with GetEnumerator and MoveNext
    loopStopwatch.Reset();
    loopStopwatch.Start();
    IEnumerator enumerator = queryResults.GetEnumerator();
    int currentIndex = 0;
    while (enumerator.MoveNext())
    {
        var moDevice = enumerator.Current as ManagementBaseObject;
        var deviceID = moDevice["DeviceID"].ToString();
        var devName = moDevice["FriendlyName"].ToString();
    }
    loopStopwatch.Stop();
    loopTime = loopStopwatch.ElapsedMilliseconds;
    loopStopwatch.Reset();
    Console.WriteLine(loopTime + " ms.  Time to perform enumerator while loop");
    Console.ReadKey();
**OUTPUT**
    24 ms.  Time to perform searcher.Get() query
    3665 ms. Time to perform Empty foreach over ManagementObjectCollection
    1 ms.  Time to perform queryResults.CopyTo array
    3 ms.  Time to perform foreach array
    1 ms.  Time to perform enumerator while loop
