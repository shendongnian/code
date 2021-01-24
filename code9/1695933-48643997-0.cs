    public class WeekComparer : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new Exception("Bad values");
            }
            var prev = values[0] as DateTime?;
            // first entry has no predecessor, so the predecessor is not a different week
            if (!prev.HasValue)
            {
                return true;
            }
            var dt1 = prev.Value;
            var dt2 = (DateTime)values[1];
            if (Math.Abs((dt1 - dt2).Days) > 7)
            {
                return false;
            }
            // assume monday to be the first day of week
            var dow1 = (dt1.DayOfWeek + 7 - DayOfWeek.Monday) % 7;
            var dow2 = (dt2.DayOfWeek + 7 - DayOfWeek.Monday) % 7;
            var result = (dow1 < dow2) == (dt1 < dt2);
            return result;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
