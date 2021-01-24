    public class MyViewModel : BaseViewModel // implements INotifyPropertyChanged
    {
    	private ICommand _myCommand;
    	
    	public ICommand MyCommand { get {return _myCommand;} private set { _myCommand = value; OnPropertyChanged(); }}
    	
    	private ObservableCollection<int> _myObjects;
    	
    	public ObservableCollection<int> MyObjects { get {return _myObjects;} private set {_myObjects = value; OnPropertyChanged();}}
    	
    	private int _mySelectedObject;
    	
    	public int MySelectedObject { get {return _mySelectedObject;} set {_mySelectedObject = value; OnPropertyChanged(); }}
    	
    	public MyViewModel 
    	{
    		MyCommand = new RelayCommand(SetSelectedObject); // the source code for RelayCommand may be found online.
    	}
    	
    	private void SetSelectedObject(object obj) 
    	{
    		int myInt = (int)obj;
    		
    		MySelectedObject = myInt;
    	}
    }
