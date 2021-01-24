    private List<Period> CondensePeriods(IEnumerable<Period> periods)
    {
        // Replace overlapping or touching periods by single period.
        List<Period> tmp = periods.ToList();
        for (int i = 0; i < tmp.Count; i++) {
            Period first = tmp[i]; // Compare this period to all following ones.
            // Loop in reverse order because we are removing entries.
            for (int j = tmp.Count - 1; j > i; j--) {
                Period condensed = first.Union(tmp[j]);
                if (condensed != null) { // Periods overlap or are touching.
                    // Replace first period with a condensed period.
                    tmp[i] = condensed;
                    // Remove the other period.
                    tmp.RemoveAt(j);
                }
            }
        }
        return tmp;
    }
