    public class ViewModel : INotifyPropertyChanged
    {
        private VirtualizingCollection<LinesSummary> _test;
        public VirtualizingCollection<LinesSummary> test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged("test");  }
        }
        public void x(FileSummarizer fs)
        {
            //set the property, not the field:
            test = new VirtualizingCollection<LinesSummary>(fs, 100);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
