    var keys = ConfigurationManager.AppSettings.AllKeys;
    foreach (var key in keys)
    {
        Console.WriteLine(key);
    }
    Console.ReadLine();
