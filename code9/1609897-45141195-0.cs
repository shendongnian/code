    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public DelegateCommand<string> NavigationCommand { get; set; }
        public BaseViewModel()
        {
            NavigationCommand = new DelegateCommand<string>(OnNavigate);
        }
        private void OnNavigate(string navPath)
        {
            switch (navPath)
            {
                case "customers":
                    CurrentViewModel = new CustomersViewModel(this);
                    break;
                ...
            }
        }
