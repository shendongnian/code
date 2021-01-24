    public WeinCamWindow(WeinCamWorkPiece camViewModel)
    {
        ViewModel = camViewModel;
        InitializeComponent();
        DataContext = ViewModel;
        this.Resources["EntitySelectionManager"] = ViewModel.SelectorManager;
    }
    
