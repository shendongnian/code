    private void DateChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
    {
        if (args.AddedDates != null && args.AddedDates.Count > 0)
        {
            var myDate = args.AddedDates.First();
            string parsedDate = myDate.ToString();
        }
    }
