    DateTime date = new DateTime(2016, 10, 30);
    int amount = 8; //amount of years
    for (int i = 1; i < amount + 1; i++)
    {
        Console.WriteLine("On {0} in {1}", date.AddYears(i).DayOfWeek, date.AddYears(i).Year);
    }
