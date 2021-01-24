        public class UrlCount
    {
        public string Url { get; set; }
        public int Count { get; set; }
    }
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private ObservableCollection<UrlCount> _urLsCount =new ObservableCollection<UrlCount>()
        {
            new UrlCount()
            {
                Count = 1,
                Url = "Url1"
            },
            new UrlCount()
            {
                Count = -1,
                Url = "Url2"
            },
        };
        public ObservableCollection<UrlCount> UrLsCount
        {
            get { return _urLsCount; }
            set
            {
                if (Equals(value, _urLsCount)) return;
                _urLsCount = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
