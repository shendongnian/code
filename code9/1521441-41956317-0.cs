    public class DateConverter : IValueConverter
    {
        private DateTime timePickerDate;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            timePickerDate = ((DateTime)(value));
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return timePickerDate;
            var datePickerDate = ((DateTime)(value));
            // compare relevant parts manually
            if (datePickerDate.Hour != timePickerDate.Hour
                || datePickerDate.Minute != timePickerDate.Minute
                || datePickerDate.Second != timePickerDate.Second)
            {
                // correct the date picker value
                var result = new DateTime(datePickerDate.Year,
                     datePickerDate.Month,
                     datePickerDate.Day,
                     timePickerDate.Hour,
                     timePickerDate.Minute,
                     timePickerDate.Second);
                // return, because this event handler will be executed a second time
                return result;
            }
            return datePickerDate;
        }
    }
