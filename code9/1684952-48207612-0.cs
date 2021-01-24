    private bool _initialized = false;
    public MainWindow1()
    {
    	InitializeComponent();
    	
    	_initialized = true;
    }
    private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
    	if (!_initialized)
    		return;
    	//....
    }
