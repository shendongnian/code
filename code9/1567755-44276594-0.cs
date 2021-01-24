    private void HamburgerMenuLoaded(object sender, RoutedEventArgs e)
	{
		if (sender is HamburgerMenu hamburgerMenu)
		{
			if (hamburgerMenu.Template.FindName("ButtonsListView", hamburgerMenu) is ListBox listBox)
			{
				var style = new Style(typeof(ListBoxItem))
							{
								BasedOn = listBox.ItemContainerStyle
							};
				style.Triggers.Add(new DataTrigger
								   {
									   Binding = new Binding(nameof(ITabViewModel.ShowTab)),
									   Value = false,
									   Setters =
									   {
										   new Setter(VisibilityProperty, Visibility.Collapsed)
									   }
								   });
				listBox.ItemContainerStyle = style;
			}
		}
	}
