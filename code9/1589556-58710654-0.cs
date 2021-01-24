      public static bool IsInRange(this DateTime dateToCheck, DateTime? startDate, DateTime? endDate)
        {
            return (startDate.HasValue && dateToCheck.Date >= startDate.Value.Date) &&
                   (endDate.HasValue && dateToCheck.Date <= endDate.Value.Date);
        }
