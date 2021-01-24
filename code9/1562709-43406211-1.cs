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
    		await Task.Run(async ()=> await AddChildAsync(rect));
    	}
    }
    
    private async Task AddChildAsync(Rectangle rect)
    {
    	await Application.Current.Dispatcher.InvokeAsync(()=> Others.Children.Add(rect));
    }
