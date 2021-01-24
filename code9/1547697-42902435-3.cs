	// Dependency Property is Private since I only need it internally
	private static readonly DependencyProperty scrollable_width_property =
			DependencyProperty.Register(nameof(scrollable_width), typeof(double),
				typeof(MyUserControl),
				new FrameworkPropertyMetadata(null) { BindsTwoWayByDefault = false, PropertyChangedCallback = property_changed_callback });
	// Wrapper only has get because ScrollableWidth is read only anyway
	private double scrollable_width => (double)GetValue(scrollable_width_property);
	// Listening to the change
	private static void property_changed_callback(DependencyObject dpo, DependencyPropertyChangedEventArgs args)
	{
		var o = dpo as MyUserControl;
		o?.SetButtonVisibility((double)args.NewValue > 0);
	}
