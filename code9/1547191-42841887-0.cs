     public class ColorConverter : IValueConverter {
                object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
                    return ((string)value.Contains("Color");
                }
            
                object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
                    throw new NotImplementedException();
                }
                 
            }
