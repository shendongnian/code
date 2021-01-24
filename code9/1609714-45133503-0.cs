    internal class MvvmTestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private SettingsViewModel SettingsViewModel;
        public MvvmTestViewModel()
        {
            SettingsViewModel = new SettingsViewModel();
            SettingsViewCommand = new RelayCommand<int>(SettingsWindow);
        }
        public ICommand SettingsViewCommand
        {
            get;
            private set;
        }
        public void SettingsWindow(int index)
        {
            SettingsViewModel.SettingsSelectedIndex = index;
            SettingsView settingsView = new SettingsView()
            {
                DataContext = SettingsViewModel
            };
            settingsView.ShowDialog();
        }
    }
