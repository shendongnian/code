    public static IEnumerable<Item> ClosestTo(IEnumerable<Item> items, TimeSpan interval)
    {
        return items.GroupBy(x =>
            {
                var time = x.DateTime.TimeOfDay;
                // Find the time that is closest to the start of interval
                var timeFloor = time.TotalMilliseconds - (time.TotalMilliseconds % interval.TotalMilliseconds);
                return x.DateTime.Date.AddMilliseconds(timeFloor);
            }).Select(x => x.OrderBy(i => i.DateTime).First());
    }
