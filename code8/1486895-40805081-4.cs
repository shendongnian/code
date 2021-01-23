    public RelayCommand MyCommand 
    { 
        get; 
        private set; 
    }
      
    public MainViewModel() 
    { 
        MyCommand = new RelayCommand(ExecuteMyCommand); 
    } 
      
    private void ExecuteMyCommand() 
    { 
        // Do the work You expect
        // Close the menu
    }
