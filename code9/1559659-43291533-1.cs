    public static bool IsInRange(this DateTime dateToCheck, string[] startDates, string[] endDates, out DateTime StartDate, out DateTime EndDate)
        {
            if (startDates.Length != endDates.Length)
            {
                throw new ArgumentException("The arrays must have the same length");
            }
            StartDate = new DateTime();
            EndDate = new DateTime();
            for (int i = 0; i < startDates.Length; i++)
            {
                StartDate = Convert.ToDateTime(startDates[i]);
                EndDate = Convert.ToDateTime(endDates[i]);
                if (dateToCheck >= StartDate && dateToCheck <= EndDate)
                {
                    return true;
                }
            }
            return false;
        }
