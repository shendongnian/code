    public class BoolToVisibilityConverter: IValueConverter 
    {
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    var rv = Visibility.Visible;
		    try
		    {
			    if (value != null)
				    rv = (bool)value ? Visibility.Visible : Visibility.Collapsed;
		    }
		    catch
		    {
			    // ignored
		    }
		    return rv;
	    }
	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    return (value != null) && (value == (object)Visibility.Visible);
	    }
    }
