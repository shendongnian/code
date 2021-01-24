    public partial class MainWindow : Window
    {
       public MainWindow()
       {
          InitializeComponent();
       }
       public void SwitchToSecondView(object sender, outedEventArgs e)
       {
          var view = new SecondView();
          var model = new SecondViewModel(this);
          view.DataContext = model;
          MainContent.Content = view;
       }
       public void SwitchToThirdView(object sender, outedEventArgs e)
       {
          var view = new ThirdView();
          var model = new ThirdViewModel(this);
          view.DataContext = model;
          MainContent.Content = view;
       }
    }
