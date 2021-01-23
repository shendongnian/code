    public IEnumerable<LocalDate> DatesInInterval(Interval interval, DateTimeZone zone)
    {
        LocalDate start = interval.Start.InZone(zone).Date;
        ZonedDateTime endZonedDateTime = interval.End.InZone(zone);
        LocalDate end = endLocalDateTime.Date;
        if (endLocalDateTime.TimeOfDay == LocalTime.Midnight)
        {
            end = end.PlusDays(-1);
        }
        for (LocalDate date = start; date <= end; date = date.PlusDays(1))
        {
            yield return date;
        }
    }
