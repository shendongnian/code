    List<DateTime> selected = new List<DateTime>();
    private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
    {
        for   (DateTime dt = monthCalendar1.SelectionStart.Date; 
                        dt.Date <= monthCalendar1.SelectionEnd.Date; 
                        dt = dt.AddDays(1))
        {
            if (!monthCalendar1.BoldedDates.Contains(dt)
            && !selected.Contains(dt)) selected.Add(dt.Date);
        }
    }
