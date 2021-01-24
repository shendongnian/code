    public double AvailabilityPercentage(IEnumerable<Period> breaks, Period period)
    {
        // First replace overlapping or touching break periods by single period.
        breaks = CondensePeriods(breaks);
        // Now remove these non-overlapping breaks from the tested period.
        long totalPeriodDuration = period.Duration.Ticks;
        long available = totalPeriodDuration;
        foreach (Period brk in breaks) {
            // Take part of break that lies within the tested period.
            var intersection = brk.Intersect(period);
            if (intersection != null) { // Break is not outside of period.
                available -= intersection.Duration.Ticks;
            }
        }
        return 100.0 * available / totalPeriodDuration;
    }
