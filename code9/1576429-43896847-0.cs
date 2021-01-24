    var lateFridays = selectedShifts.Where(s =>
        s.ShiftType == ShiftType.Late && s.Day.DayOfWeek == DayOfWeek.Friday);
    
    var earlyMondays = selectedShifts.Where(r =>
        r.Day.DayOfWeek == DayOfWeek.Monday && r.ShiftType == ShiftType.Early);
    
    var matchingPairs = lateFridays.SelectMany(earlyMondays, Tuple.Create)
        .Where(t => t.Item2.Day.AddDays(-2).DayOfYear == t.Item1.Day.DayOfYear);
    var count = matchingPairs.Count();
