    public static class CalendarViewHelper
    {
        public static DateTimeOffset GetSelectedDate(DependencyObject obj)
        {
            return (DateTimeOffset)obj.GetValue(SelectedDateProperty);
        }
        public static void SetSelectedDate(DependencyObject obj, DateTimeOffset value)
        {
            obj.SetValue(SelectedDateProperty, value);
        }
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.RegisterAttached("SelectedDate", typeof(DateTimeOffset), typeof(CalendarView),
                new PropertyMetadata(null, (d, e) =>
                {
                    var cv = (CalendarView)d;
                    var date = (DateTimeOffset)e.NewValue;
                    cv.SelectedDates.Clear();
                    cv.SelectedDates.Add(date);
                }));
    }
