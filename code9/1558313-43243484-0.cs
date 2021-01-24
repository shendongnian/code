    class BreakRangeToBooleanConverterTime : IValueConverter
    {
        private static readonly TimeSpan _toCompare = new TimeSpan(00, 15, 00);
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeSpan))
                return DependencyProperty.UnsetValue;
            
            return (TimeSpan)value > _toCompare;
        }      
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("To Long On Lunch");
        }       
    }
