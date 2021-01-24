    public class Container : INotifyPropertyChanged
    {
        private int _total;
        private static InjectionContainer _mainContainer = new InjectionContainer();
        private static InjectionContainer _secondContainer = new InjectionContainer();
        private ObservableCollection<MyData> _files = new ObservableCollection<MyData>();
        public int TotalPackets
        {
            get { return _total; }
        }
        public ObservableCollection<MyData> List
        {
            get { return _files; }
            set { _files = value; }
        }
        public void AddTotal(int value)
        {
            Interlocked.Add(ref _total, value);
            OnPropertyChanged("Total");
        }
    }
