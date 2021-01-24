    public class Converter : IValueConverter
     {
         public object Convert(object value, Type targetType, object parameter, string language)
         {
             return value;
    
         }
    
         public object ConvertBack(object value, Type targetType, object parameter, string language)
         {
             return value as ComboBoxItem;
         }
     }
