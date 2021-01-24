    private readonly TopMenuViewModel _viewModel;
    
    public YourController(TopMenuViewModel viewModel)
    {
    	if (viewModel == null)
    	{
    		throw new ArgumentNullException(nameof(viewModel));
    	}
    
    	_viewModel = viewModel;
    }
