    var inputs = new List<inputDate>
    {
        new inputDate(1,1,2018),
        new inputDate(32,1,2018),
        new inputDate(1,13,2018),
        new inputDate(1,1,-2018)
    };
    foreach (var input in inputs)
    {
        GetDayOfBirth(input);
    }
    private void GetDayOfBirth(inputDate input)
    {
        CultureInfo invC = CultureInfo.InvariantCulture;
        if (DateTime.TryParseExact(
                $"{input.D}/{input.M}/{input.Y}",
                $"d/M/yyyy",
                invC,
                DateTimeStyles.None,
                out DateTime birthday)
            )
        {
            Console.WriteLine("You were born on a:" + birthday.DayOfWeek);
            return;
        }
        Console.WriteLine("Invalid date");
    }
