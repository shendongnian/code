    <DataGrid.Resources>
                <Style TargetType="DataGridCell">
                    <EventSetter Event="PreviewMouseLeftButtonDown" Handler="PreviewMouseDown"/>
                </Style>
            </DataGrid.Resources>
    private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
    		{
    			var cell = sender as DataGridCell; if (cell == null) { return; }
    			DataGrid parGrid = null;
    			var visParent = VisualTreeHelper.GetParent(cell);
    			while (parGrid==null && visParent != null)
    			{
    				parGrid = visParent as DataGrid;
    				visParent = VisualTreeHelper.GetParent(visParent);
    			}
    			if (parGrid==null) { return; }
    
    			e.Handled = cell.IsSelected && Keyboard.Modifiers == ModifierKeys.None && parGrid.SelectedItems.Count > 1;
    		}
