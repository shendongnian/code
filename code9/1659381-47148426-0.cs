    var customCulture = new CultureInfo("en-US")
    {
        DateTimeFormat =
        {
            ShortDatePattern = "yyyy-MM-dd",
            LongTimePattern = "HH:mm:ss.FFFFFFFK"
        }
    };
    Console.WriteLine(DateTime.Now);
    System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
    System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;
    Console.WriteLine(DateTime.Now);
    Console.ReadLine();
