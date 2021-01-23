    public MyViewModel ViewModel {get; set;}
    
    public View()
    {
        this.InitializeComponent();
         
        ViewModel = new MyViewModel();
    }
