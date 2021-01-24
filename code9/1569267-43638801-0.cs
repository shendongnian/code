    public class MainViewModel: INotifyPropertyChanged
    {
        public int HostName { get => hostName; set { hostName = value; OnPropertyChanged("HostName"); } }
        private int hostName;
        ...
        void OnPropertyChanged(String prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
