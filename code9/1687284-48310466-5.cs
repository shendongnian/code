    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _Tab_SelectedIndex = 0;
        public int Tab_SelectedIndex
        {
            get
            {
                return _Tab_SelectedIndex;
            }
            set
            {
                _Tab_SelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Tab_SelectedIndex"));
            }
        }
        public MainWindowViewModel()
        {
            IntAggregator.OnDataTransmitted += OnDataReceived;
        }
        private void OnDataReceived(int data)
        {
            Tab_SelectedIndex = data;
        }
    }
