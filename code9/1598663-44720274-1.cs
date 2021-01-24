    public partial class MainWindow : Window
    {
       public MainWindow()
       {
          InitializeComponent();
       }
       private void SwitchView(object sender, outedEventArgs e)
       {
          var view = new SecondView();
          var model = new SecondViewModel();
          view.DataContext = model;
          MainContent.Content = view;
       }
    }
