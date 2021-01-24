        private DateTime GetBeforeDateExcludeWeekends(DateTime FromDate, int Period)
        {
            DateTime tillBeforeDate = FromDate.Subtract(TimeSpan.FromDays(Period));
 
            var weekendDayCnt = 
                Enumerable.Range(0, (FromDate - tillBeforeDate).Days + 1).Select(d => tillBeforeDate.AddDays(d))
                .Where(day => day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                .Count();
            return FromDate.Subtract(TimeSpan.FromDays(Period + weekendDayCnt));
        }
