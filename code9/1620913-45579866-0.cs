    public static void Main()
    {
        var dayList = new List<DayOfWeek>();
        var str = "Mon-Thu, Sun";
        str = str.Replace(" ", string.Empty);   // remove spaces
        // split groups by comma
        var split = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in split) // process each group
        {
            // split ranges by hyphen
            var elements = item.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);  // split group into elements
            switch (elements.Length)
            {
                case 1:
                    // add single element
                    dayList.Add((DayOfWeek) GetDayIndex(elements[0]));
                    break;
                case 2:
                    // add range of elements
                    dayList.AddRange(GetDayRange(elements[0], elements[1]));
                    break;
                default:
                    Console.WriteLine($"Input line does not match required format: \"{str}\"");
                    break;
            }
        }
        // prove it works
        for (var index = 0; index < dayList.Count; index++)
        {
            var separator = string.Empty;
            if (index > 0)
            {
                separator = ", ";
            }
            Console.Write($"{separator}{dayList[index]}");
        }
        Console.WriteLine();
    }
    private static int GetDayIndex(string dayNameAbbreviation)
    {
        return Array.IndexOf(CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedDayNames, dayNameAbbreviation);
    }
    private static IEnumerable<DayOfWeek> GetDayRange(string beginDayNameAbbrev, string endDayNameAbbrev)
    {
        var dayRange = new List<DayOfWeek>();
        for (var i = GetDayIndex(beginDayNameAbbrev); i <= GetDayIndex(endDayNameAbbrev); i++)
        {
            dayRange.Add((DayOfWeek) i);
        }
        return dayRange;
    }
