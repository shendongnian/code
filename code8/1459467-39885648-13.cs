    [TestMethod]
    public void TestString()
    {
        int counter = 10000000;
        for (var x = 0; x < counter; x++)
            DictString.Add(x.ToString(), "hello");
        TimedLog("10,000,000 hits TryGet", () =>
        {
            for (var x = 0; x < counter; x++)
                Assert.IsFalse(string.IsNullOrEmpty(GetValue1String(x.ToString())));
        }, Console.WriteLine);
        TimedLog("10,000,000 hits ContainsKey", () =>
        {
            for (var x = 0; x < counter; x++)
                Assert.IsFalse(string.IsNullOrEmpty(GetValue2String(x.ToString())));
        }, Console.WriteLine);
        TimedLog("10,000,000 misses TryGet", () =>
        {
            for (var x = counter; x < counter*2; x++)
                Assert.IsTrue(string.IsNullOrEmpty(GetValue1String(x.ToString())));
        }, Console.WriteLine);
        TimedLog("10,000,000 misses ContainsKey", () =>
        {
            for (var x = counter; x < counter*2; x++)
                Assert.IsTrue(string.IsNullOrEmpty(GetValue2String(x.ToString())));
        }, Console.WriteLine);
    }
    [TestMethod]
    public void TestInt()
    {
        int counter = 10000000;
        for (var x = 0; x < counter; x++)
            DictInt.Add(x, "hello");
        TimedLog("10,000,000 hits TryGet", () =>
        {
            for (var x = 0; x < counter; x++)
                Assert.IsFalse(string.IsNullOrEmpty(GetValue1Int(x)));
        }, Console.WriteLine);
        TimedLog("10,000,000 hits ContainsKey", () =>
        {
            for (var x = 0; x < counter; x++)
                Assert.IsFalse(string.IsNullOrEmpty(GetValue2Int(x)));
        }, Console.WriteLine);
        TimedLog("10,000,000 misses TryGet", () =>
        {
            for (var x = counter; x < counter * 2; x++)
                Assert.IsTrue(string.IsNullOrEmpty(GetValue1Int(x)));
        }, Console.WriteLine);
        TimedLog("10,000,000 misses ContainsKey", () =>
        {
            for (var x = counter; x < counter * 2; x++)
                Assert.IsTrue(string.IsNullOrEmpty(GetValue2Int(x)));
        }, Console.WriteLine);
    }
    public static void TimedLog(string message, Action toPerform, Action<string> logger)
    {
        var start = DateTime.Now;
        if (logger != null)
            logger.Invoke(string.Format("{0} Started at {1:G}", message, start));
        toPerform.Invoke();
        var end = DateTime.Now;
        var span = end - start;
        if (logger != null)
            logger.Invoke(string.Format("{0} Ended at {1} lasting {2:G}", message, end, span));
    }
