    public MainWindow()
    {
        InitializeComponent();
        grid1.DataContext = vm = new MyViewModel()
        {
            DataItems =
            {
                new ItemVM(),
            },
            ComboItems =
            {
                "A",
                "AAAAAAAAAAAAAAAAAAAAAAA"
            }
        };
    }
    public class MyViewModel
    {
        private ObservableCollection<ItemVM> _DataItems = new ObservableCollection<ItemVM>();
        public ObservableCollection<ItemVM> DataItems
        {
            get { return _DataItems; }
        }
        private ObservableCollection<string> _ComboItems = new ObservableCollection<string>();
        public ObservableCollection<string> ComboItems
        {
            get { return _ComboItems; }
        }
    }
    public class ItemVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent([CallerMemberName]string prop = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; RaisePropertyChangedEvent(); }
        }
    }
