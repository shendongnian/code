    // Order Schedules using System.Linq
    public class ToOrderedListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<ScheduleItem> schedules = (List<ScheduleItem>)value;
            var subset = from item in schedules
                         orderby item.MyDateTime.TimeOfDay
                         orderby item.MyDateTime.ToString("yyyy/MM/dd") descending
                         select item;
            return subset.ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    // Show only first occurrence of date
    public class DateToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime currentItem = (DateTime)values[0];
            List<ScheduleItem> schedules = (List<ScheduleItem>)values[1];
            ScheduleItem firstOccurrence =
                schedules.Find(item => item.MyDateTime.Year == currentItem.Year
                                    && item.MyDateTime.Month == currentItem.Month
                                    && item.MyDateTime.Day == currentItem.Day);
            if (firstOccurrence.MyDateTime == currentItem)
                return Visibility.Visible;
            else return Visibility.Collapsed;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
