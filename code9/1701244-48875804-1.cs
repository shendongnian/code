    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {    
    	for (int i = 0; i < DataGrid.Items.Count; i++)
    	{
    		DataGridRow row = (DataGridRow)DataGrid.ItemContainerGenerator.ContainerFromIndex(i);
    		TextBlock cellContent = DataGrid.Columns[0].GetCellContent(row) as TextBlock;
    		if (cellContent != null && cellContent.Text.Equals(DataGrid.SelectedItem))
    		{
    			object item = DataGrid.Items[i];
    			DataGrid.SelectedItem = item;
    			DataGrid.ScrollIntoView(item);
    			row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    			break;
    		}
    	}
    }
