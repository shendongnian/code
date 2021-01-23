    public HeaderView()
    {
        if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
        {
            var svc = ServiceLocator.Current;
            var eventAggregator = svc.GetInstance<IEventAggregator>();
            this.DataContext = new HeaderViewModel(eventAggregator);
         }
         InitializeComponent();
    }
