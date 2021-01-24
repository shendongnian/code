    int currentYear;
    while (true)
    {
        var currentYearText = Console.ReadLine();
        if (int.TryParse(currentYearText, out currentYear))
        {
            // User entered a valid integer
            // Validating that integer
            if (currentYear > 2000 && currentYear < 2050)
            {
                break;
            }
        }
        Console.Write("Please enter valid year between 2000 and 2050");
    }
