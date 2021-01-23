	private int PreviousIndex;
	private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ListView lv = sender as ListView;
		if (PreviousIndex >=0)
		{
			ListViewItem prevItem = (lv.ContainerFromIndex(PreviousIndex)) as ListViewItem;
			prevItem.ContentTemplate = Resources["NoSelectDataTemplate"] as DataTemplate;
		}
		ListViewItem item = (lv.ContainerFromIndex(lv.SelectedIndex)) as ListViewItem;
		item.ContentTemplate = Resources["SelectDataTemplate"] as DataTemplate;
		PreviousIndex = lv.SelectedIndex;
	}
