     public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value != null)
                {
                    DateTime date = (DateTime)value;
                    return new DateTimeOffset(date);
                }
                return new DateTimeOffset(DateTime.Now);
            }
            catch (Exception)
            {
                return DateTimeOffset.MinValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
    }
