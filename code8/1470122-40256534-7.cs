    public class PresenterViewModel : BaseViewModel
    {
    	private readonly IDataService _dataService;
    
    	public PresenterViewModel(IDataService dataService)
    	{
    		_dataService = dataService;
    	}
    }
