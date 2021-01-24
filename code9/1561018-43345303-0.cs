    public class MyBgConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, string language)
    	{
    		var b = (bool)value;
    		var color = b ? Colors.Yellow : Colors.Green;
    
    		return new SolidColorBrush(color);
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, string language)
    	{
    		throw new NotImplementedException();
    	}
    }
