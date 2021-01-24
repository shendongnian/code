    class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void _UpdatePropertyField<T>(
            ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class Item : NotifyPropertyChangedBase
    {
        private string _name;
        private string _imagePath;
        private BitmapSource _bitmap;
        public string Name
        {
            get { return _name; }
            set { _UpdatePropertyField(ref _name, value); }
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set { _UpdatePropertyField(ref _imagePath, value); }
        }
        public BitmapSource Bitmap
        {
            get { return _bitmap; }
            set { _UpdatePropertyField(ref _bitmap, value); }
        }
    }
    class MainWindowModel : NotifyPropertyChangedBase
    {
        public MainWindowModel()
        {
            _RunTimer();
        }
        private async void _RunTimer()
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (true)
            {
                await Task.Delay(1000);
                TotalSeconds = sw.Elapsed.TotalSeconds;
            }
        }
        private ObservableCollection<Item> _data = new ObservableCollection<Item>();
        public ObservableCollection<Item> Data
        {
            get { return _data; }
        }
        private double _totalSeconds;
        public double TotalSeconds
        {
            get { return _totalSeconds; }
            set { _UpdatePropertyField(ref _totalSeconds, value); }
        }
        private double _loadSeconds;
        public double LoadSeconds
        {
            get { return _loadSeconds; }
            set { _UpdatePropertyField(ref _loadSeconds, value); }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        private readonly MainWindowModel _model = new MainWindowModel();
        public MainWindow()
        {
            DataContext = _model;
            InitializeComponent();
            _LoadItems();
        }
        private async void _LoadItems()
        {
            foreach (Item item in _GetItems())
            {
                _model.Data.Add(item);
            }
            foreach (Item item in _model.Data)
            {
                BitmapSource itemBitmap = await Task.Run(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    // forces immediate load on EndInit() call
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(item.ImagePath, UriKind.Relative);
                    bitmap.DecodePixelWidth = 278;
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    sw.Stop();
                    _model.LoadSeconds += sw.Elapsed.TotalSeconds;
                    return bitmap;
                });
                item.Bitmap = itemBitmap;
            }
        }
        private static IEnumerable<Item> _GetItems()
        {
            for (int i = 1; i <= 60; i++)
            {
                Item newItem = new Item
                {
                    ImagePath = String.Format(@"Images/{0}.jpg", i),
                    Name = "Item: " + i
                };
                yield return newItem;
            }
        }
    }
