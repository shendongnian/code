    `private void Value1_KeyUp(object sender, KeyRoutedEventArgs e)
      {
		if (e.Key == VirtualKey.Enter)
		{
			string value = Value1.Text;
			PivotItem pi = MainPivot.SelectedItem;
			((WebView)pi.Content).Navigate(new Uri(value,
            UriKind.Absolute));   
			MainPivot.SelectedItem = pi;
			TagTextBlock.Text = Value1.Text;
			pi.Header = ((WebView)pi.Content).DocumentTitle;
		}
	}
`
