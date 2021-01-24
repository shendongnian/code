    public class MyConverter : System.Windows.Data.IValueConverter {
        public object Convert ( object value , Type targetType , object parameter , CultureInfo culture ) {
            if ( value == null )
                return System.Windows.Visibility.Hidden;
            if ( parameter == null )
                return System.Windows.Visibility.Hidden;
            if ( value.ToString().Equals ( parameter ) )
                return System.Windows.Visibility.Visible;
            return System.Windows.Visibility.Hidden;
        }
        public object ConvertBack ( object value , Type targetType , object parameter , CultureInfo culture ) {
            throw new NotImplementedException ( );
        }
    }
