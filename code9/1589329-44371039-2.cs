    public static List<DateTime> GetBirthdaysBetweenDates(DateTime minDate, DateTime maxDate, int number = 1)
    {
        if(minDate > maxDate) throw new ArgumentException("minDate can't be greater then maxDate");
    
        var dates = new List<DateTime>();
        if(number <= 0) return dates;
        var rnd = new Random();
        var ticks = maxDate.Ticks - minDate.Ticks;
        for(var i = 0; i < number; i++)
        {
            var toAdd = (long)(rnd.NextDouble() * ticks);
            dates.Add(new DateTime(minDate.Ticks + toAdd));
        }
        
        return dates;
    }
