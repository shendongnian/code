    public class InverseBoolConverter : IValueConverter, IMarkupExtension
    	{
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    		{
    			return !((bool)value);
    		}
    
    		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    		{
    			return value;
    			//throw new NotImplementedException();
    		}
    
    
    		public object ProvideValue(IServiceProvider serviceProvider)
    		{
    			return this;
    		}
    	}
