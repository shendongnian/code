    private void dg_UnloadingRow(object sender, DataGridRowEventArgs e)
    		{
    			if (((sender as DataGrid).DataContext as ViewModel).YourItemSourceProperty.Count == 0)
    			{
    				Close();
    			}
    		}
