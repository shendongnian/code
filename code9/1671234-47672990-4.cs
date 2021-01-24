    public class PercentConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (value == null)
    			return 0;
    		var valor = (int)(int.Parse(value.ToString()) * 0.8); //80% of my Window Height
    		return valor;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		var valor = (int)(int.Parse(value.ToString()) / 0.8);
    		return valor;
    	}
    }		
