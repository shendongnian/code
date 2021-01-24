    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
    	if (value == null)
    	{
    		return new SolidColorBrush(Colors.White);
    	}
    
    	switch (value.ToString().ToLower())
    	{
    		case "opcion1":
    			return new SolidColorBrush(Colors.Aqua);
    		case "opcion2":
    			return new SolidColorBrush(Colors.Cyan);
    		case "opcion3":
    			return new SolidColorBrush(Colors.Brown);
    		case "opcion4":
    			return new SolidColorBrush(Colors.DarkGreen);
    		default:
    			return new SolidColorBrush(Colors.White);
    	}
    }
