        private void _calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
        //If the user click the button of the calendar to change year, the calendar must remains open
            if (e.RemovedDate.HasValue && e.AddedDate.HasValue)
            {
                if (e.RemovedDate.Value.Year == e.AddedDate.Value.Year)
                {
                    btn.IsChecked = false;
                }
            }
        }
        private void Popup_Opened(object sender, EventArgs e)
        {
            _calendar.DisplayMode = CalendarMode.Year;
        }
