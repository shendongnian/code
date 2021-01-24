    public partial class TestPage : UserControl
    {
      public TestPage()
      {
	  InitializeComponent();
	  this.Loaded += TestListPage_Loaded;
	  this.DataContext = this;
      }	
      private async void TestListPage_Loaded(object sender, RoutedEventArgs e)
      {
       ShortCutUtils.ImplementShortCut(this);
      }
    }
