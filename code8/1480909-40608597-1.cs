    public partial class MainWindow  
    {
        public MainWindow()
        {
            this.InitializeComponent();
    
            DataContext = new MainViewModel();
        }
    }
    
    public class MainViewModel : ViewModelBase
    {
        private bool _isLoginVisible;
        public bool IsLoginVisible
        {
            get
            {
                return _isLoginVisible;
            }
            set
            {
                _isLoginVisible = value;
                OnPropertyChanged();
            }
        }
    }
