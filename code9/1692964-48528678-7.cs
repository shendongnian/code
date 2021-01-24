    public double AvailabilityPercentage(IEnumerable<Period> breaks, Period period)
    {
        // First replace overlapping or touching break periods by single period.
        List<Period> tmpBreaks = breaks.ToList();
        for (int i = 0; i < tmpBreaks.Count; i++) {
            Period a = tmpBreaks[i]; // Compare this break period to all following ones.
            // Loop in reverse order because we are removing entries.
            for (int j = tmpBreaks.Count - 1; j > i; j--) {
                Period b = tmpBreaks[j];
                if (a.OverlapsOrTouches(b)) {
                    // Replace first break period with a period covering both.
                    tmpBreaks[i] = new Period(
                        new DateTime(Math.Min(a.Start.Ticks, b.Start.Ticks)),
                        new DateTime(Math.Max(a.End.Ticks, b.End.Ticks))
                    );
                    // Remove the other break period
                    tmpBreaks.RemoveAt(j);
                }
            }
        }
        // Now remove these non-overlapping breaks from the tested period.
        long totalPeriodLength = (period.End - period.Start).Ticks;
        long available = totalPeriodLength;
        foreach (Period brk in tmpBreaks) {
            if (brk.OverlapsOrTouches(period)) {
                // Make sure the break limits are within given period.
                long start = Math.Max(period.Start.Ticks, brk.Start.Ticks);
                long end = Math.Min(period.End.Ticks, brk.End.Ticks);
                available -= end - start;
            }
        }
        return 100.0 * available / totalPeriodLength;
    }
