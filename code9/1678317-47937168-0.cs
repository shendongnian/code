    var cd = new ContentDialog();
    var cdProps = cd.GetType().GetProperties();
    foreach (var propInfo in cdProps)
    {
    	if (typeof(Button).IsAssignableFrom(propInfo.PropertyType))
    	{
    		var textBlock = (Button)(cd.GetType().GetProperty(propInfo.Name).GetValue(cd, null));
    		// Do stuff with it
    	}
    	if (typeof(TextBlock).IsAssignableFrom(propInfo.PropertyType))
    	{
    		var textBlock = (TextBlock)(cd.GetType().GetProperty(propInfo.Name).GetValue(cd, null));
    		// Do stuff with it
    	}
    }
