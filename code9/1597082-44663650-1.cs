    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
    {
        base.OnElementChanged(e);
		if (Control == null)
		{
		    return;
		}
		var customPicker = e.NewElement as CustomPicker;
		if (customPicker != null)
		{
		    Control.TextSize = Convert.ToSingle(customPicker.FontSize);
		}
	}
