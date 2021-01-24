    public class MainViewModel: ViewModelBase
    {
    	private ViewModelBase _currentViewModel;
    
    
    	public ViewModelBase CurrentViewModel
    	{
    		get => _currentViewModel;
    		set
    		{
    			if (_currentViewModel == value)
    				return;
    			_currentViewModel = value;
    
    			OnPropertyChanged(nameof(CurrentViewModel));
    		}
    	}
    
    	public MainViewModel()
    	{
    
    	}
    
    	protected override void Navigate(object args)
    	{
    		var namespaceName = "YourNameSpace.";
    		var className = args.ToString();
    		var fullClassName = string.Concat(namespaceName, (string)className);
    		if (string.IsNullOrEmpty(fullClassName))
    			return;
    		var tipo = Type.GetType(fullClassName);
    		if (tipo == null)
    			return;
    
    		var myObj = Activator.CreateInstance(tipo) as ViewModelBase;
    		if (myObj != null)
    			CurrentViewModel = (ViewModelBase)myObj;
    
    	}
    
    }
