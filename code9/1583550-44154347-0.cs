    <Image x:Name="imgSettings"  Source="img/settings_blue.png" Stretch="None" MouseDown="Mouse_Down" />
		
    private void Mouse_Down(object sender, MouseButtonEventArgs e)
    		{
    			DataGridRow gridRowGettingSelection = null;
    			var visParent = VisualTreeHelper.GetParent(sender as FrameworkElement);
    			while (gridRowGettingSelection == null && visParent != null)
    			{
    				gridRowGettingSelection = visParent as DataGridRow;
    				visParent = VisualTreeHelper.GetParent(visParent);
    			}
    			if (gridRowGettingSelection == null) { return; }
    
    			Equipment classObj = gridRowGettingSelection.DataContext as Equipment;
    			string cellValue = classObj.EQNr;
    
    			lblArtikel.Content = "Equipment: " + cellValue;
    			Dispatcher.BeginInvoke((Action)(() => tbControlETK.SelectedIndex = 1));
    
    		}
