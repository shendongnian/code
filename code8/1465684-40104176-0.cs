     private static int FindIndex(DateTime timeIntervalFrom, DateTime timeIntervalTo, DateTime searchDate)
        {
            var index = -1;
            if (searchDate.CompareTo(timeIntervalFrom) >= 0 && searchDate.CompareTo(timeIntervalTo) <= 0)
            {
                index = (searchDate.Year - timeIntervalFrom.Year) * 12
                    + (searchDate.Month > timeIntervalFrom.Month ? searchDate.Month - timeIntervalFrom.Month
                    : searchDate.Month + 12 - timeIntervalFrom.Month);
            }
            return index;
        }
