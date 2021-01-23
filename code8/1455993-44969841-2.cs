      public class CalendarDatePickerEx : CalendarDatePicker
      {
        public DateTimeOffset? DefaultValue { get; set; }
    
        public static readonly DependencyProperty DefaultValueProperty =
          DependencyProperty.Register("DefaultValue", typeof(DateTimeOffset), typeof(CalendarDatePickerEx), new PropertyMetadata(null, (sender, e) =>
          {
            if ((DateTimeOffset?)e.NewValue != null && ((CalendarDatePickerEx)sender).Date.Value.Date.Year == DateTime.Today.Year - 100)
            {
              ((CalendarDatePickerEx)sender).SetDisplayDate((DateTimeOffset)e.NewValue);
              ((CalendarDatePickerEx)sender).Date = null;
            }
            else if ((DateTimeOffset?)e.NewValue == null && ((CalendarDatePickerEx)sender).Date.Value.Date.Year == DateTime.Today.Year - 100)
            {
              {
                ((CalendarDatePickerEx)sender).SetDisplayDate(DateTimeOffset.Now);
                ((CalendarDatePickerEx)sender).Date = null;
              }
            }
          }));
      }
