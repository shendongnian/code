    // your DownlodArticles command's execute method
    public void Execute(object parameter)
    {
    	var articles = _dataService.DownloadArticles();
    	Articles = new ObservableCollection(articles);
    }
