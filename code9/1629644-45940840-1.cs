    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
	{
		var dockPanel = FindChild<DockPanel>(myAwesomePane);
		if (dockPanel != null)
		{
			var button = new Button {Content = "Help", Margin = new Thickness(1), Width = 40};
			button.Click += (o, args) => MessageBox.Show(this, "HELP");
			DockPanel.SetDock(button, Dock.Right);
			dockPanel.Children.Insert(dockPanel.Children.Count - 1, button);
		}
	}
	/// <summary>
	/// Find first child of given type
	/// </summary>
	public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
	{
		var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
		T result = null;
		for (int i = 0; i < childrenCount; i++)
		{
			var dObj = VisualTreeHelper.GetChild(parent, i);
			result = dObj as T;
			if (result != null)
			{
				break;
			}
			result = FindChild<T>(dObj);
			if (result != null)
			{
				break;
			}
		}
		return result;
	}
