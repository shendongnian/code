    protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
    {
    	base.OnElementChanged(e);
    	....
    	UpdateBackground();
    }
    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
    	base.OnElementPropertyChanged(sender, e);
        if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
            UpdateBackground();
    }
	void UpdateBackground()
	{
        if (Control == null || Element == null)
            return;
        if (Element.IsEnabled)
            Control.BackgroundColor = ..;
        else
            Control.BackgroundColor = ..;
	}
