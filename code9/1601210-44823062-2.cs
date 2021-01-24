    public partial class TestPage : UserControl
    {
      public TestPage(Cdt cdt, Session session, bool sessionReadOnly)
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
