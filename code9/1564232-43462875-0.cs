    private async void Button_Click(object sender, RoutedEventArgs e)
    {
    	for (int j = 0; j < 5; j++)
    	{
    		Food1.Visibility = Visibility.Collapsed;
    		Food2.Visibility = Visibility.Collapsed;
    		Food3.Visibility = Visibility.Collapsed;
    		Food4.Visibility = Visibility.Collapsed;
    
    		int ImageToDisplay = RandomFood.Next(0, 4);
    
    		if (ImageToDisplay == 0)
    		{
    			Food1.Visibility = Visibility.Visible;
    		}
    		else if (ImageToDisplay == 1)
    		{
    			Food2.Visibility = Visibility.Visible;
    		}
    		else if (ImageToDisplay == 2)
    		{
    			Food3.Visibility = Visibility.Visible;
    		}
    		else if (ImageToDisplay == 3)
    		{
    			Food4.Visibility = Visibility.Visible;
    		}
    
    		await Task.Delay(1000);
    	}
    }
