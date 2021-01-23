    private void ComboBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    		{
    			Point pt = e.GetPosition((ComboBox)sender);
    
    			clicked = null;
    			VisualTreeHelper.HitTest(
    				(ComboBox)sender,
    				null,
    				new HitTestResultCallback(ResultCallback),
    				new PointHitTestParameters(pt));
    
    
    			if (clicked != null)
    			{
    				((ComboBox)sender).IsDropDownOpen = false;
    
    				//do something
    			}
    		}
