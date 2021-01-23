    public bool IsHoliday(DateTime requesteddate, HolidayType type)
    {
      var holidays = GetHolidays(requesteddate.Year, type);
      return holidays.Any(h => DateTime.Equals(h.Date, requesteddate));
    }
