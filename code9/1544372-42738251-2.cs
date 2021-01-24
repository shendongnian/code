    public ObservableCollection<PublishedDateModel> PublishedDateModels { get; set; }
    
            public MainWindow()
            {
                PublishedDateModels = new ObservableCollection<PublishedDateModel>(new[]
                {
                    new PublishedDateModel(DateTime.Now), 
                    new PublishedDateModel(DateTime.Now.AddDays(1)), 
                    new PublishedDateModel(DateTime.Now.AddDays(-1)), 
                });
                InitializeComponent();
            }
