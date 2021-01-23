    internal class MainWindowViewModel
    {
    	private readonly DialogService dialogService;
    
    	private ICommand dummyCommand;
    
    	public MainWindowViewModel()
    	{
    		dialogService = new DialogService();
    	}
    
    	public ICommand DummyCommand
    	{
    		get { return dummyCommand ?? (dummyCommand = new RelayCommand<object>(p => Dummy())); }
    	}
    
    	private async void Dummy()
    	{
    		Logic1();
    		await dialogService.ShowMvvmMessageBox("Question1?", "Q1?");
    		Logic2();
    		await dialogService.ShowMvvmMessageBox("Question2", "Q2");
    		Logic3();
    	}
    
    	private void Logic1()
    	{
    		// So some logic here
    	}
    
    	private void Logic2()
    	{
    		// So some logic here
    	}
    
    	private void Logic3()
    	{
    		// So some logic here
    	}
    }
