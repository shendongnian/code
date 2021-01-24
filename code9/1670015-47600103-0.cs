    public async void button_Click(object sender, RoutedEventArgs e)
    {
        if (youtube_ids.Count > 0)
        {
    		DownloadLinks.Visibility = Visibility.Visible;
    		foreach (var youtube_id in youtube_ids)
    		{
    
    				var grid = new Grid();
    				grid.Width = 400;
    				grid.Height = 50;
    			
    
    
    			// image thumbnail
    			var thumb = new Image();
    
    			thumb.Width = 50;
    			thumb.MaxHeight = 50;
    			thumb.Margin = new System.Windows.Thickness { Left = 10 };
    
    
    			var thumb_file = new BitmapImage(new Uri($"http://img.youtube.com/vi/{youtube_id}/0.jpg", UriKind.Absolute));
    			thumb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
    			thumb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
    			thumb_file.DownloadCompleted += (ob, ev) =>
    			{
    				thumb.Source = thumb_file;
    
    
    
    			};
    			grid.Children.Add(thumb);
    			DownloadLinks.Items.Add(grid);
    		**}**
        }
    }
