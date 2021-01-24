    var orasTs = oras.Select(o => ParseTimeSpan(o))
                     .Where(ts => !(ts.TotalHours >= 7 && ts.TotalHours <= 10.5f))
                     .ToArray();
        private static TimeSpan ParseTimeSpan(string t)
        {
            int hoursToAdd = 0;
            if (t.EndsWith("AM"))
            {
                hoursToAdd = 0;
            }
            else
            {
                hoursToAdd = 12;
            }
            return TimeSpan.Parse(t.Substring(0, 5)).Add(TimeSpan.FromHours(hoursToAdd));
        }
