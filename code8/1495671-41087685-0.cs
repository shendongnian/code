    private bool _canExecuteMyCommand = true;
    public RelayCommand YourCommand 
    { 
      get; 
      private set; 
    } 
      
    public MainViewModel() 
    { 
      MyCommand = new RelayCommand( MethodToCall, () => _canExecuteMyCommand); 
    } 
      
    private void MethodToCall() 
    { 
      // Do something 
    }
