    public MainViewModel viewModel { get; set; }
      public MainPage()
      {
          this.InitializeComponent();      
          viewModel = this.DataContext as MainViewModel;
          viewModel.items.Add(new Model() { imageSource = "ImageTest.hello.jpg" });
          viewModel.items.Add(new Model() { imageSource= "ImageTest.hello.jpg" });
              MyGridView.ItemsSource = viewModel.items;
      }
