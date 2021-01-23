    namespace VexLibrary.DesktopClient.ViewModels
    {
        public class MainViewModel : ViewModel
        {
            private ViewModel _currentViewModel;
    
            public MainViewModel()
            {
                _currentViewModel = new DashboardViewModel(this);
            }
    
            public ViewModel CurrentViewModel
            {
                get { return _currentViewModel; }
                private set
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
    }
