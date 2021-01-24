    public partial class SecondView : Page, IViewFor<SecondViewModel>
    {
        public SecondViewModel ViewModel { get; set; }
        object IViewFor.ViewModel { get => ViewModel; set { ViewModel = (SecondViewModel)value; } }
        public SecondView(SecondViewModel viewModel)
        {
            ViewModel = viewModel;
            this.WhenActivated(disposables =>
            {
                ViewModel.GoBack.Subscribe(_ =>
                    {
                        DoSomethingHard();
                        if (NavigationService != null) NavigationService.GoBack();
                    })
                    .DisposeWith(disposables);               
                this.WhenAnyValue(p => p.ViewModel)
                    .BindTo(this, x => x.DataContext)
                    .DisposeWith(disposables);
            });        
        InitializeComponent();            
        }        
    }
