    namespace SO40564064
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          DataContext = new ViewModel();
        }    
      }
    }
