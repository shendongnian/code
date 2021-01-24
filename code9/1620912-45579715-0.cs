    static void Main(string[] args)
    {
        var input = "Fri-Thu, Sun";
        var consecutiveChunks = input.Split(new[] { ',' }, 
            StringSplitOptions.RemoveEmptyEntries);
        var output = new List<DayOfWeek>();
        var daysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
        foreach (var chunk in consecutiveChunks)
        {
            var chunkRange = chunk.Split('-').Select(i => i.Trim()).ToList();
            DayOfWeek currentDay = daysOfWeek
                .First(d => d.ToString().StartsWith(chunkRange[0]));
            DayOfWeek lastDay = chunkRange.Count > 1
                ? daysOfWeek.First(d => d.ToString().StartsWith(chunkRange[1])) 
                : currentDay;
            output.Add(currentDay);
            // If we have a range of days, add the rest of them
            while (currentDay != lastDay)
            {
                // Increment to the next day
                if (currentDay == DayOfWeek.Saturday)
                {
                    currentDay = DayOfWeek.Sunday;
                }
                else
                {
                    currentDay++;
                }
                output.Add(currentDay);
            }
        }
        // Output our results:
        Console.WriteLine($"The ranges, \"{input}\" resolve to:");
        output.ForEach(i => Console.WriteLine(i.ToString()));
        
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
