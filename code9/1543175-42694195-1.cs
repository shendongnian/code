            DateTime start = new DateTime(2017, 01, 01);
            DateTime end = new DateTime(2017, 01, 10);
            TimeSpan ts = end - start;
            
            List<DateTime> workingDays = new List<DateTime>();
            for(DateTime dt = start; dt <= end; dt = dt.AddDays(1))
            {
                if(dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
                    workingDays.Add(dt);
            }
            int holidays = workingDays.Intersect(bankHolidays).Count();
            int result = workingDays.Count - holidays;
