    DateTime d1 = DateTime.Now;
    DateTime d2 = DateTime.Now.AddSeconds(5);
    DateTime d3 = DateTime.Now.AddSeconds(15);
    DateTime d4 = DateTime.Now.AddSeconds(30);
    DateTime d5 = DateTime.Now.AddSeconds(32);
			
    List<DateTime> times = new List<DateTime>() { d1, d2, d3, d4, d5 };
			
    var withinSeven = times.OrderBy(t => t)
        .Where((t, i) =>
            i > 0 && t.Subtract(times[i - 1]).Seconds < 7)
        .ToList();
			
    foreach (var time in withinSeven)
        Console.WriteLine(time);
