	private void DataGrid_OnPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		if (e.Command == DataGrid.DeleteCommand)
		{
			// Show MessageBox and get result
			if (result == No)
			{
				// Cancel Delete command by setting Handled = true
				e.Handled = true;
			}
			else
			{
				// execute you delete SQL		
			}
		}
	}
 
