    static void Main(string[] args)
    {
        // Loop 12 times (once for each month)
        for (int i = 1; i < 13; i++)
        {
            // Get the first day of the current month
            var month = new DateTime(2017, i, 1);
            // Print out the month, year, and the days of the week
            Console.WriteLine($"{month.ToString("MMMM")} {month.Year}");
            Console.WriteLine("Su Mo Tu We Th Fr Sa");
            // Get the number of days we need to leave blank at the 
            // start of the week. 
            var padLeftDays = (int)month.DayOfWeek;
            var currentDay = month;
            // Print out the day portion of each day of the month
            for (int j = 0; j < DateTime.DaysInMonth(month.Year, month.Month); j++)
            {
                // Pad the first week with empty spaces if needed
                if (j < padLeftDays)
                {
                    Console.Write("   ");
                }
                else
                {
                    // Write the day - pad left adds a space before single digit days
                    Console.Write($"{currentDay.Day.ToString().PadLeft(2, ' ')} ");
                    // If we've reached the end of a week, start a new line
                    if ((j + 1) % 7 == 0)
                    {
                        Console.WriteLine();
                    }
                    // Increment our 'currentDay' to the next day
                    currentDay = currentDay.AddDays(1);
                }
            }
            // Put a blank space between months
            Console.WriteLine("\n");
        }
        Console.Write("\nDone!\nPress and key to exit...");
        Console.ReadKey();
    }
