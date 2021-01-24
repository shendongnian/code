    var pinAnnotationView = annotationView as MKPinAnnotationView;
    if (pinAnnotationView != null)
    {
    	pinAnnotationView.AnimatesDrop = AnimateOnPinDrop;
    
    	var pinTintColorAvailable = pinAnnotationView.RespondsToSelector(new Selector("pinTintColor"));
    
    	if (!pinTintColorAvailable)
    	{
    		return;
    	}
    
    	if (pin.DefaultPinColor != Color.Default)
    	{
    		pinAnnotationView.PinTintColor = pin.DefaultPinColor.ToUIColor();
    	}
    	else
    	{
    		pinAnnotationView.PinTintColor = UIColor.Red;
    	}
    }
