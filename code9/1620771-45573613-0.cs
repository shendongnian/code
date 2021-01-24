    private void DateChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
    {
        var myDate = args.AddedDates.FirstOrDefault();
        if (myDate != null)
        {
            string parsedDate = myDate.ToString();
        }
    }
