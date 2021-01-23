     public ViewModel viewModel { get; set; }      
     public MainPage()
     {          
         this.InitializeComponent();
         this.viewModel = this.DataContext as ViewModel;
                             
     }
    
     private void MyButton_Click(object sender, RoutedEventArgs e)
     {   
         viewModel.Uname = MainPage.UNAME;
     }
