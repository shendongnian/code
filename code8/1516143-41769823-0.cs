    static IEnumerable<DateTime> CombineDateTimes(IEnumerable<IEnumerable<DateTime>> list) {
        // keep track of which enumerators are still available
        var eligible = list.Select(l => l.GetEnumerator()).Where(l => l.MoveNext()).ToList();
        while (eligible.Any()) {
            // find the lowest enumerator
            IEnumerator<DateTime> min = eligible.First();
            foreach (var l in eligible.Skip(1)) {
                if (l.Current < min.Current) {
                    min = l;
                }
            }
            // here is our lowest
            yield return min.Current;
            if (!min.MoveNext()) {
                // if the enumerator ends,
                // remove it from the list of eligible enumerators
                eligible = eligible.Remove(min);
            }
        }
    }
