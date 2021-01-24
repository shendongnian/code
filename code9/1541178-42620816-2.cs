    public ICommand DrillDownCommand
    {
    	get
    	{
    		return new RelayCommand<ChartPoint>(this.OnDrillDownCommand);
    	}
    }
    		
    private void OnDrillDownCommand(ChartPoint chartPoint)
    {
    	// access the chartPoint.Instance (Cast it to YourObjectHere and access its properties)
    }
