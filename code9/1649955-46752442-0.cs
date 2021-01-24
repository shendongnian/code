    timer.Tick += delegate (object sender, object e)
    {
    	var selectedItem = FavoritesListBox.SelectedItem;
    
    	if (selectedItem == null)
    	{
    		return;
    	}
    
    	var tb = (TextBlock)selectedItem.Content;
    
    	if (tb.Text != MiniTextBlock.Text)
    	{
    		FavoritesListBox.SelectedIndex = -1;
    	}
    };
