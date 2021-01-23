    private function Tuple<DateTime, DateTime> ParseDate(string dateTimes)
    {
        var split = dateTimes.Split(' to ');
        var time1 = DateTime.ParseExact(split[0], "h:mm tt",
                                            CultureInfo.InvariantCulture);
        var time2 = DateTime.ParseExact(split[1], "h:mm tt",
                                            CultureInfo.InvariantCulture);
    
        return new Tuple.Create(time1, time2);
    }
    
    
    private function bool NotConflict(IEnumerable<string> times, time) {
        var incTime = ParseDate(time);
        
        return times.All(t => {
            var parsed = ParseDate(t);
            return incTime.Item1 =< parsed.Item1 && incTime.Item2 <= parsed.Item1 && incTime.Item1 >= parsed.Item2 && incTime.Item2 >= parsed.Item2;
        });
    }
