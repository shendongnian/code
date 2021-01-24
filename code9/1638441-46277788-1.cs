    public class MyStatusToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Status status = (Status)value;
            // maybe use a switch statement depending on number of cases?
            if (status == Status.SomeValue || status == Status.SomeOtherValue)
                return Brushes.Brushes.Transparent;
            else
            {
                // ...
            }
        }
    }
