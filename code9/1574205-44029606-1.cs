    private void OnCalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
    {
        // Render basic day items.
        if (args.Phase == 0)
        {
            // Register callback for next phase.
            args.Item.DataContext = GetCalJobItemVM(args.Item.Date);
        }
    }
