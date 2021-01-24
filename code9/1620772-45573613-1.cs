    private void DateChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
    {
        if(args.AddedDates != null || args.AddedDates.Any())
        {
            var myDate = args.AddedDates.First();
            string parsedDate = myDate.ToString();
        }
    }
