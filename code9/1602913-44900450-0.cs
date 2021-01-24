    public class DecimalConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                    return value.ToString().Replace(",", ".");
                else
                    return value.ToString().Replace(".", ",");
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                    return value.ToString().Replace(".", ",");
                else
                    return value.ToString().Replace(",", ".");
            }
    
        }
