    public class BooleanInverseVisibilityConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, string language)
    	{
    		return (bool)value ? Visibility.Collapsed : Visibility.Visible;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, string language)
    	{
    		return (Visibility)value != Visibility.Visible;
    	}
    }
