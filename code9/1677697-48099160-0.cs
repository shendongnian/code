    private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
    	if (e.EditAction == DataGridEditAction.Commit)
    	{
    		var bindingGroup = e.Row.BindingGroup;
    		if (bindingGroup != null && bindingGroup.IsDirty && bindingGroup.CommitEdit())
    		{
    			var item = (PageItemViewModel)e.Row.Item;
    			if (string.IsNullOrEmpty(item.Text))
    			{
    				e.Cancel = true;
    				((DataGrid)sender).CancelEdit();
    			}
    		}
    	}
    }
