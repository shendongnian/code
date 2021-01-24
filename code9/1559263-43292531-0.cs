    interface IApiRepository
    {
    	Task<ObservableCollection<ApiModel>> GetApiModelsAsync();
    }
    
    class ApiRepository : IApiRepository
    {
    	private async Task<ObservableCollection> GetApiModelsAsync()
    	{
    		var myCollection = new ObservableCollection<ApiModel>();
    		var result = await DoMyApiCall();
    		foreach (result as item)
    		{
    			var newModel = new ApiModel();
    			newModel.fillFromApi(item);
    			myCollection.Add(newModel);
    		}
    		return myCollection;
    	}	
    }
    
    
    class MyViewModel : ViewModelBase
    {
    	private readonly IApiRepository _apiRepository;
    	
    	public MyViewModel(IApiRepository apiRepository)
    	{
    		_apiRepository = apiRepository;
    		InitializeViewModel();
    	}
    	
    	private ObservableCollection<ApiModel> _apiModels;
    	public ObservableCollection<ApiModel> ApiModels
    	{
    		get { return _apiModels; }
    		set { Set(ref _apiModels, value); }
    	}
    	
    	private async void InitializeViewModel()
    	{
    		//as soon as the repo is finished ApiModels will raise the RaisePropertyChanged event
    		ApiModels = await _apiRepository.GetApiModelsAsync();
    	}
    }
    
    //in you ViewModelLocator
    SimpleIoC.Default.Register<IApiRepository, ApiRepository>();
