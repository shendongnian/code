    public static IEnumerable<DateTime> SortDates(IEnumerable<IEnumerable<DateTime>> iidt)
    {
        var enumerators = iidt.Select(iedt => iedt.GetEnumerator())
                            .Where(e => e.MoveNext())
                            .ToList();
        enumerators.ForEach(e => e.MoveNext());
        while (enumerators.Any())
        {
            var lowest = enumerators.OrderBy(e => e.Current).First();
            yield return lowest.Current;
            if (!lowest.MoveNext())
            {
                enumerators.Remove(lowest);
            }
        }
    }
