    DateTime dateTime = DateTime.Now;
    double oleTime = dateTime.ToOADate();
    DateTime convertedTime = DateTime.FromOADate(oleTime);
    
    Console.WriteLine(dateTime.Ticks.ToString());
    Console.WriteLine(oleTime.ToString());
    Console.WriteLine(convertedTime.Ticks.ToString());
