    public class DatetimeToPassedDateConverter : IValueConverter,MarkupExtension
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            if(value is DateTime)
                return DateTime.Now-(DateTime)value;
            else
                return null;
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // Convert back which is not required in your case
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
