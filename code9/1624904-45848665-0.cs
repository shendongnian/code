    public class CalendarItemFacade : ICalendarItem
    {
        private ICalendarItem _calendarItem;
        public CalendarItemFacade(ICalendarItem calendarItem)
        {
            _calendarItem = calendarItem;
        }
        public DateTime StartTime => _calendarItem.StartTime;
        // All other interface implementations follow here
    }
