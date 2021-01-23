    public List<ProcessInfo> ProcessListTable
    {
    	get { return listTable?? (listTable = JsonConvert.DeserializeObject<List<ProcessInfo>>(File.ReadAllText(pathToFile));); }
    }
    
    public ProcessInfo SelectedProcessItem
    {
    	get { return _selectedProcessItem; }
    	set
    	{
    		if (Equals(value, _selectedProcessItem)) return;
    		_selectedProcessItem = value;
    		OnPropertyChanged();
    	}
    }
