    public class SelectedToColorConverter : IValueConverter
    {
    
    	#region IValueConverter implementation
    
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (value is bool)
    		{
    			if ((Boolean)value)
    				return Color.Red;
    			else
    				return Color.Black;
    		}
    		return Color.Black;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    
    	#endregion
    }
