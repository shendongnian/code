	private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
	{
	    // Only act on Commit
	    if (e.EditAction == DataGridEditAction.Commit)
	    {
	        //execute your update SQL
	    }
	}
