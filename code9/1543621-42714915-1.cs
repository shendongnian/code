    public class MainWindowViewModel : INotifyPropertyChanged
        {
            private OtherViewModel otherVM;
            private HomeViewModel homeVM;
    
            public DelegateCommand<string> NavigationCommand { get; private set; }
    
            public MainWindowViewModel()
            {
                otherVM = new OtherViewModel();
                homeVM = new HomeViewModel();
    
                // Setting default: homeViewModela.
                CurrentViewModel = homeVM;
    
                NavigationCommand = new DelegateCommand<string>(OnNavigate);
            }
    
            private void OnNavigate(string navPath)
            {
                switch (navPath)
                {
                    case "other":
                        CurrentViewModel = otherVM;
                        break;
                    case "home":
                        CurrentViewModel = homeVM;
                        break;
                }
            }
    
            private object _currentViewModel;
            public object CurrentViewModel
            {
                get { return _currentViewModel; }
                set
                {
                    if (_currentViewModel != value)
                    {
                        _currentViewModel = value;
                        OnPropertyChanged();
                    }
                }
            }
    
    
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
              PropertyChanged(this, new propertyChangedEventArgs(propertyName));
            }
            #endregion
        }
