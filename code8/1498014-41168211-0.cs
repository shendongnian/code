    public class MainWindowProperties : INotifyPropertyChanged
    {
        public bool StartButtonEnabled { get; set; }
        private string _selectedProcess;
        public string SelectedProcess
        {
            get { return _selectedProcess; }
            set { _selectedProcess = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
