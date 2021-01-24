        public static DateTime GetEndDate(int year, int month, bool firstHalfOfMonth)
        {
            if (firstHalfOfMonth == false)
            {
                return GetStartDate(year, month, false);
            }
            else
            {
                return new DateTime(year, month, System.DateTime.DaysInMonth(year, month));
            }
        }
        public static DateTime GetStartDate(int year, int month, bool firstHalfOfMonth)
        {
            if (firstHalfOfMonth == false)
            {
                int daysInCurrentMonth = System.DateTime.DaysInMonth(year, month);
                int midMonth = Convert.ToInt32(Math.Ceiling((double)daysInCurrentMonth / 2));
                return new DateTime(year, month, midMonth);
            }
            else
            {
                return new DateTime(year, month, 1);
            }
        }
