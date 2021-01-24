    public MainViewModel()
{
	//Get access to the ViewModelLocator
	ViewModelLocator viewModelLocator = System.Windows.Application.Current.Resources["Locator"] as ViewModelLocator;
	
	_sourcenContentUserControl = new MyUserControl();
	_sourcenContentUserControl.DataContext = viewModelLocator.MyUserControlSourceVM;
	var dataContext = _sourcenContentUserControl.DataContext as MyUserControlViewModel ;
	dataContext.SetSource; 
    _sourcenContent = _sourcenContentUserControl;    
		
	_targetContentUserControl = new MyUserControl();
	_targetContentUserControl.DataContext = viewModelLocator.MyUserControlTargetVM;
	dataContext = _targetContentUserControl.DataContext as MyUserControlViewModel ;
    dataContext.SetTarget; 
    _targetContent = _targetContentUserControl;
