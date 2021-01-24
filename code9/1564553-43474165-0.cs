    DateTime firstDateTime = new DateTime(2017, 04, 18, 0, 0, 0);
    DateTime secondDateTime = new DateTime(2017, 04, 18, 0, 0, 8);
    TimeSpan span = new TimeSpan(0, 0, 0, 7, 0);
    if (secondDateTime - firstDateTime <= span)
    {
        Console.WriteLine("OK");
    }
    else
    {
        Console.WriteLine("NOT OK");
    }
