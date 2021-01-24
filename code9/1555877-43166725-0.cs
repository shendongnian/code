    private void showResultsListWithDataGrid()
      {
    	List<ResultsListItem> listItem = new List<ResultsListItem>();
    	for(int i=1; i<=10; i++)
    	{
    		listItem.Add(new ResultsListItem
    		{
    			Index = "index" + i,
    			Result = "result" + i,
    			HyperLink = "hyperlink" + i
    		});
    	}
    	this.dataGrid.ItemsSource = listItem; //datagrid should be declared on the xaml file
    }
