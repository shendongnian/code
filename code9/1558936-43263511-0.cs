    var thing = DbConnector.Query("SELECT First_Name FROM users ");
    foreach(var i in thing)
    {
        foreach(var item in thing.Values)
        {
            System.Console.WriteLine(item.Key);
            System.Console.WriteLine(item.Value);
        }
    }
