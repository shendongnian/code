    static IEnumerable<Period> GetPeriods (DateTime start, DateTime end)
    {
        // Create a DateTime as a pointer to increment
        DateTime ptr = start;
        while (ptr < end)
        {
            // Return a new Period, starting with the current pointer time and ending with
            //   the pointer time plus 00:59:59 (3600s)
            yield return new Period() { Start = ptr, End = ptr.AddSeconds(3599) };
            // Increment the pointer
            ptr = ptr.AddHours(1);
        }
    }
