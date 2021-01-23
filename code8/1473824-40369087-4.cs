    namespace WpfApplication1
    {
        public class MainVM : INotifyPropertyChanged
        {
            public MainVM()
            {
                InitialiseComponents();
            }
            private void InitialiseComponents()
            {
                LoginCommand = new RelayCommand(loginCommandMethod);
            }
            private string searchKey;
            public string SearchKey
            {
                get { return searchKey; }
                set { searchKey = value; OnPropertyChanged("SearchKey"); }
            }
            private RelayCommand _loginCommand;
            public RelayCommand LoginCommand
            {
                get { return _loginCommand; }
                private set { _loginCommand = value; }
            }
            private void loginCommandMethod(object parameter)
            {
                // do something
            }
            #region INotify
            public void OnPropertyChanged(string prop)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            public event PropertyChangedEventHandler PropertyChanged; 
            #endregion
        }
    }
