    foreach (int year in years)
    {
        if (IsLeapYear(year))
        {
            Console.WriteLine($"{year} is a leap year");
        }
        else
        {
            Console.WriteLine($"{year} is not a leap year");
        }
    }
