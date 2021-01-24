    public delegate void UsernameChangedEventHandler(string username);
    
    public class FirstPageViewModel : INotifyPropertyChanged
    {
    	// 3) Third implementation
    	public event UsernameChangedEventHandler UsernameChanged;
    
    	private string _username;
    	public string UserName
    	{
    		get { return _username; }
    		set
    		{
    			_username = value;
    
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
    
    			if (UsernameChanged != null)
    				UsernameChanged(this.UserName);
    		}
    	}
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class SecondPageViewModel : INotifyPropertyChanged
    {
    
    	private string _username;
    	public string UserName
    	{
    		get { return _username; }
    		set
    		{
    			_username = value;
    
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
    		}
    	}
    
    	public SecondPageViewModel()
    	{
    	}
    
    	public SecondPageViewModel(FirstPageViewModel parent)
    	{
    		// 1) First implementation
    		parent.PropertyChanged += FirstPageViewModel_OnPropertyChanged;
    
    		// 3) Third Implementation
    		parent.UsernameChanged += Parent_UsernameChanged;
    	}
    
    	private void Parent_UsernameChanged(string username)
    	{
    		this.UserName = username;
    	}
    
    	private void FirstPageViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs args)
    	{
    		FirstPageViewModel parent = (FirstPageViewModel) sender;
    		if(args.PropertyName.Equals("username", StringComparison.InvariantCultureIgnoreCase))
    		{
    			this.UserName = parent.UserName;
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class ParentViewModel : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private FirstPageViewModel _firstPageViewModel;
    	private SecondPageViewModel _secondPageViewModel;
    
    	public ParentViewModel()
    	{
    		// 2) Second implementation
    		_firstPageViewModel = new FirstPageViewModel();
    		_secondPageViewModel = new SecondPageViewModel();
    
    		_firstPageViewModel.PropertyChanged += FirstPageViewModel_PropertyChanged;
    
    
    		// 3) Third Implementation
    		_firstPageViewModel.UsernameChanged += FirstPageViewModel_UsernameChanged;
    	}
    
    	private void FirstPageViewModel_UsernameChanged(string username)
    	{
    		_secondPageViewModel.UserName = username;
    	}
    
    	private void FirstPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs args)
    	{
    		FirstPageViewModel firstPageViewModel = (FirstPageViewModel)sender;
    		if (args.PropertyName.Equals("username", StringComparison.InvariantCultureIgnoreCase))
    		{
    			_secondPageViewModel.UserName = firstPageViewModel.UserName;
    		}
    	}
    }
