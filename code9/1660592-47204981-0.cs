        public static DateTime? GetNextAdjustmentDate(TimeZoneInfo timeZoneInfo)
        {
            var adjustments = timeZoneInfo.GetAdjustmentRules();
            if (adjustments.Length == 0)
            {
                return null;
            }
            int year = DateTime.UtcNow.Year;
            TimeZoneInfo.AdjustmentRule adjustment = null;
            foreach (TimeZoneInfo.AdjustmentRule adjustment1 in adjustments)
            {
                // Determine if this adjustment rule covers year desired 
                if (adjustment1.DateStart.Year <= year && adjustment1.DateEnd.Year >= year)
                    adjustment = adjustment1;
            }
            if (adjustment == null)
                return null;
            //TimeZoneInfo.TransitionTime startTransition, endTransition;
            DateTime dstStart = GetCurrentYearAdjustmentDate(adjustment.DaylightTransitionStart);
            DateTime dstEnd = GetCurrentYearAdjustmentDate(adjustment.DaylightTransitionEnd);
            if (dstStart >= DateTime.UtcNow.Date)
                return dstStart;
            if (dstEnd >= DateTime.UtcNow.Date)
                return dstEnd;
            return null;
        }
        private static DateTime GetCurrentYearAdjustmentDate(TimeZoneInfo.TransitionTime transitionTime)
        {
            int year = DateTime.UtcNow.Year;
            if (transitionTime.IsFixedDateRule)
                return new DateTime(year, transitionTime.Month, transitionTime.Day);
            else
            {
                // For non-fixed date rules, get local calendar
                System.Globalization.Calendar cal = CultureInfo.CurrentCulture.Calendar;
                // Get first day of week for transition 
                // For example, the 3rd week starts no earlier than the 15th of the month 
                int startOfWeek = transitionTime.Week * 7 - 6;
                // What day of the week does the month start on? 
                int firstDayOfWeek = (int)cal.GetDayOfWeek(new DateTime(year, transitionTime.Month, 1));
                // Determine how much start date has to be adjusted 
                int transitionDay;
                int changeDayOfWeek = (int)transitionTime.DayOfWeek;
                if (firstDayOfWeek <= changeDayOfWeek)
                    transitionDay = startOfWeek + (changeDayOfWeek - firstDayOfWeek);
                else
                    transitionDay = startOfWeek + (7 - firstDayOfWeek + changeDayOfWeek);
                // Adjust for months with no fifth week 
                if (transitionDay > cal.GetDaysInMonth(year, transitionTime.Month))
                    transitionDay -= 7;
                return new DateTime(year, transitionTime.Month, transitionDay);
            }
        }
