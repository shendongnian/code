    DateTime datetime1 = DateTime.Now;
    DateTime datetime2 = DateTime.Now;
    if (datetime2.Subtract(datetime1).TotalSeconds < 7)
    {
        Console.WriteLine("Less than 7 seconds");
    }
