    public class MyConverter : IValueConverter, IMarkupExtension
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (Equals(value,null))
                    return string.Empty;
    
                var obj = (ClassA)value;
                // Your logic here to work out the string to display
                // NOTE: untested - may need to add null checks, etc.
                if (obj.Types[0].Count > 0 && obj.Types[1].Count > 0) 
                {
                    return "type 1 count: " + Types[0].Count + "type 2: count: " Types[1].Count;
                }
                else if (obj.Types[0].Count > 0)
                {
                    return Types[0].Count;
                }
                return string.Empty;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException("Only one way bindings are supported with this converter");
            }
    
            public object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
