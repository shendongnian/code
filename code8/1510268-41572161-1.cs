    public static ICommand MyCommand { get; set; } // declare an ICommand - bind to this!
    
    public MainViewModel(IDataService dataService)
    {
        // associate your ICommand with a method.  If you don't use a parameter, you don't need the lambda expression here.
        MyCommand = new RelayCommand((paramater) => MyCommandMethod(parameter));
    }
    
    public void MyCommandMethod(string parameter)
    {
        Debug.WriteLine("This is the code I want to run in my VM. The parameter is " + parameter);
    }
