	public BindablePicker() 
	{
		if (Device.OS == TargetPlatform.iOS) 
		{
			this.Unfocused += OnUnfocused; 
		}
		else
		{
			this.SelectedIndexChanged += OnSelectedIndexChanged; 
		} 
	} 
	private void OnUnfocused(object sender, FocusEventArgs e) 
	{ 
		OnSelectedIndexChanged(sender, e);
	} 
