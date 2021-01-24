	public SelectionFrame()
	{
		f1 = new Frame
		{
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center,
			Padding = new Thickness(0),
			CornerRadius = 7,
			HeightRequest = 14,
			WidthRequest = 14,
			Content = f2
		};
		
		f1.SetBinding(Frame.BackgroundColorProperty, new Binding(nameof(BorderColor)));
		f1.BindingContext = this;
		
		Content = f1;
	}
