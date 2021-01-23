    public ObservableCollection<string> Name { get; set; }
    public ObservableCollection<string> Result { get; set; }
    
    private List<Results> _AllResults;
    
    public List<Results> AllResults
    {
    	get
    	{
    		return _AllResults;
    	}
    	set
    	{
    		_AllResults = value;
    
    		Name.Clear();
    		Result.Clear();
    
    		foreach (Results results in _AllResults)
    		{
    			Name.Add(results.Name);
    			Result.Add(results.Succeed ? "Pass" : "Fail");
    		}
    	}
    }
