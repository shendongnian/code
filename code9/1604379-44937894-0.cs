       var startDate = DateTime.Now.Date;
        var days = new List<Tuple<string, string>>();
        int totalMonths = 12;
        for (int i = 1; i < totalMonths; i++)
        {
            var tempDay = startDate.AddMonths(-i);
            days.Add(new Tuple<string, string>($"{tempDay.ToString("MMM")} {tempDay.ToString("yyyy")}", tempDay.ToString("MMM")));
        }
        foreach (var d in days)
        {
            Console.WriteLine(d.Item1);
        }
