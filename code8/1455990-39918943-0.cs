    public class CustomNewCalendarDatePicker : CalendarDatePicker
    {
    public DateTimeOffset? DefaultValue { get; set; }
    public static readonly DependencyProperty DefaultValueProperty =
      DependencyProperty.Register("DefaultValue", typeof(DateTimeOffset), typeof(CustomNewCalendarDatePicker), new PropertyMetadata(null, (sender, e) =>
      {
        if ((DateTimeOffset?)e.NewValue != null && ((CustomNewCalendarDatePicker)sender).Date.Value.Date.Year == 1916)
        {
          ((CustomNewCalendarDatePicker)sender).SetDisplayDate((DateTimeOffset)e.NewValue);
          ((CustomNewCalendarDatePicker)sender).Date = null;
        }
        else if ((DateTimeOffset?)e.NewValue == null && ((CustomNewCalendarDatePicker)sender).Date.Value.Date.Year == 1916)
        {
          {
            ((CustomNewCalendarDatePicker)sender).SetDisplayDate(DateTimeOffset.Now);
            ((CustomNewCalendarDatePicker)sender).Date = null;
          }
        }
      }));
    }
