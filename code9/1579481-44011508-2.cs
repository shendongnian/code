    public class BoolToColorValueConverter : MvxColorValueConverter
    {
        protected override MvxColor Convert(object value, object parameter, CultureInfo culture)
        {
            return (bool)value
                ? new MvxColor(255, 0, 0)
                : new MvxColor(0, 0, 0);
        }
    }
