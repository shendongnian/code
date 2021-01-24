    public Page()
    {
        InitializeComponent();
        var viewModel = Microsoft.Practices.Unity.UnityContainerExtensions.Resolve<IMyViewModel>(((App)Application.Current).Container);
        this.BindingContext = viewModel;
    }
