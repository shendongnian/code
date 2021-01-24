    public Myusercontrol ()
    {
         InitializeComponent();
         DataViewModel vm = new DataViewModel (eventAggregator);
         this.DataContext = vm;
    }
