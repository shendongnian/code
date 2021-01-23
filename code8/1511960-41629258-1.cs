    ViewModel1 vm;
    
    public DisplayLatestItemInListbox() {
    	InitializeComponent();
    	vm = new ViewModel1();
    	DataContext = vm;
    }
    
    // Use command instead.
    private void AddLogEntry_Click(object sender, RoutedEventArgs e) {
    	vm.AddLogEntry();
    }
