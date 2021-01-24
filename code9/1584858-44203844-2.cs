    public class NullStringToVisibilityConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, string language)
    	{
    		var s = (string) value;
    		return (s!=null) ? Visibility.Visible : Visibility.Collapsed;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, string language)
    	{
    		throw new NotImplementedException();
    	}
    }
