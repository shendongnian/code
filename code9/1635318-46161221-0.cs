        protected DateTime[] GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (int i=-(int)startDate.DayOfWeek, j=0;j<7;j++,i++)
                {
                    allDates.Add(startDate.AddDays(i));
                }
            return allDates.ToArray();
        }
