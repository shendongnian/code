      public partial class MainWindow : Window
        {
            public MainWindow(INotifyPropertyChanged ViewModel)
            {
                InitializeComponent();
                this.DataContext = ViewModel;
                this.Show();
            }
        }
