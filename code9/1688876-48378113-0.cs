     public class TimeStampToDate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double unixTimeStamp = System.Convert.ToDouble(value);
                System.DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                result = result.AddSeconds(unixTimeStamp).ToLocalTime();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
