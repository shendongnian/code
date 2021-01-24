    public class CruiseShipIndicatorValueConverter : MvxValueConverter<bool, int>
    {
       
        protected override int Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
            {
                return Resource.Drawable.up_arrow;
            }
            else
            {
                return Resource.Drawable.down_arrow;
            }
            if (parameter is bool)
            {
                bool value2 = (bool)parameter;
                // Here this value2 is the second boolean value.
            }
        }
        protected override bool ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
