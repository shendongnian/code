    public class StateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            if (value is State)
            {
                State state = (State)value;
                switch (state)
                {
                    case State.Away:
                    case State.Gone:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            return State.None; // your default state
        }
    }
