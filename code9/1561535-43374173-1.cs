	private void Pivot_Loaded(object sender, RoutedEventArgs e)
	{
		Pivot pivot = sender as Pivot;
		int count = VisualTreeHelper.GetChildrenCount(pivot);
		ScrollViewer scrollViewer = FindChildByName<ScrollViewer>(pivot, "ScrollViewer");
		scrollViewer.PointerEntered += (s, a) => { ((ScrollViewer)s).HorizontalScrollMode = ScrollMode.Disabled; };
		scrollViewer.PointerMoved += (s, a) => { ((ScrollViewer)s).HorizontalScrollMode = ScrollMode.Disabled; };
		scrollViewer.PointerExited += (s, a) => { ((ScrollViewer)s).HorizontalScrollMode = ScrollMode.Enabled; };
		scrollViewer.PointerReleased += (s, a) => { ((ScrollViewer)s).HorizontalScrollMode = ScrollMode.Enabled; };
		scrollViewer.PointerCaptureLost += (s, a) => { ((ScrollViewer)s).HorizontalScrollMode = ScrollMode.Enabled; };
	}
