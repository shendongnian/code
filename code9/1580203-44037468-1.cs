    TabViewModel vm { get; set; }        
    public Window1()
    {
    	vm = new TabViewModel();
    	this.DataContext = vm;            
    	InitializeComponent();
    }
