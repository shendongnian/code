    public MyViewModelClass ViewModel {get; set;}
    
    public View()
    {
        this.InitializeComponent();
         
        ViewModel = new MyViewModelClass();
    }
