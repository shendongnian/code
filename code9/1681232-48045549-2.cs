    public static IEnumerable<Item> ClosestTo(IEnumerable<Item> items, TimeSpan interval)
    {
        return items.GroupBy(item =>
        {
            // Find a date that is closest to the start of interval.
            var ticksFloor = item.DateTime.Ticks - (item.DateTime.Ticks % interval.Ticks);
            return new DateTime(ticksFloor);
        }).Select(grouping => grouping.OrderBy(item => item.DateTime).First());
    }
