    private void SetDaysInMonth()
    
    {
        this.DaysInMonth = Enumerable.Range(1, DateTime.DaysInMonth(this.MDate.Year, this.MDate.Month))
                                     .Select(day => new DateTime(this.MDate.Year, this.MDate.Month, day))
                                     .Count(d => d.DayOfWeek != DayOfWeek.Sunday && 
                                                 d.DayOfWeek != DayOfWeek.Saturday);
    }
