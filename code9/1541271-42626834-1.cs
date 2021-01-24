    public partial class MainWindow : Window, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ObservableCollection<KeyValuePair<string, float>> _values;
        public ObservableCollection<KeyValuePair<string, float>> values {
            get { return _values; }
            set {
                _values = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(values)));
            }
        }
    ....
