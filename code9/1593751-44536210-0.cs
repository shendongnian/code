    MyViewModel _MyViewModel { get; set; }
     public FareDetails()
     {
        _MyViewModel = new MyViewModel();
        BindingContext = _MyViewModel;
        InitializeComponent();
            
      }
