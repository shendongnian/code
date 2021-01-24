    DateTime firstThursday = DateTime.MinValue.AddDays(
       Enumerable.Range(0, 7).Where(d => DateTime.MinValue.AddDays(d).DayOfWeek == DayOfWeek.Thursday).First()
    );
    int weeks = (DateTime.MaxValue - DateTime.MinValue).Days / 7;
    var allThursdays = Enumerable.Range(0, weeks).Select(d => firstThursday.AddDays(d * 7));
