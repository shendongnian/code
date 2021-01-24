    // MainView
    public MainView() {
        InitializeComponent();
        if(!mvvmContext1.IsDesignMode)
            InitializeBindings();
    }
    void InitializeBindings() {
        var fluent = mvvmContext1.OfType<MainViewModel>();
        fluent.BindCommand(simpleButton1, x => x.ChildViewModel.Save());
        var childView = new ChildView(fluent.ViewModel.ChildViewModel); // pass the ViewModel
        this.panel1.Controls.Add(childView);
    }
    // Child View
    public ChildView(ChildViewModel viewModel) {
        InitializeComponent();
        if(!mvvmContext1.IsDesignMode) {
            mvvmContext1.SetViewModel(typeof(ChildViewModel), viewModel); // before any bindings
            InitializeBindings();
        }
    }
    void InitializeBindings() {
        var fluent = mvvmContext1.OfType<ChildViewModel>();
        fluent.SetObjectDataSourceBinding(childModelBindingSource, x => x.ChildData);
        fluent.BindCommand(simpleButton1, x => x.Save());
    }
