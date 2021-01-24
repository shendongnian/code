    private async void OnMainWindowLoaded(object sender, RoutedEventArgs e)
    {
    	for (var i = 0; i < 50000; i++)
    	{
    		var rect = new Rectangle
    		{
    			Fill = new SolidColorBrush(Colors.Gray),
    			Width = 200,
    			Height = 290,
    			Margin = new Thickness(5,0,5,5)
    		};
    		Others.Children.Add(rect);
            await System.Windows.Threading.Dispatcher.Yield();
    	}
    }
