        public static DayOfWeek GetOneBasedDayOfWeek(DateTime date) // date = 9/1/2016 12:00:00 AM
        {
            // returns Thursday
            return (DayOfWeek)((int)date.DayOfWeek + 1);
        }
