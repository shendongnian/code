    Models.Info info;
    InfoDetailsViewModel vm;
    public JohnDoePage(Models.Info info)
    {
        InitializeComponent();
        vm = new InfoDetailsViewModel(info);
        BindingContext = vm;
        this.info= info;
     }
