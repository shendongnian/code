    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const int BTN_NUMBERS = 25;
        private ObservableCollection<ButtonModel> _buttonsCollection;
        private ButtonModel _currentTarget;
        public ObservableCollection<int> ExcludedItems
        {
            get { return _excludedItems; }
            private set { _excludedItems = value; OnPropertyChanged(); }
        }
        private Random _rnd;
        private Timer _timer;
        private ObservableCollection<int> _excludedItems = new ObservableCollection<int>();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            ButtonsCollection = new ObservableCollection<ButtonModel>();
            for (int i = 0; i < BTN_NUMBERS; i++)
            {
                ButtonsCollection.Add(new ButtonModel() { ButtonNumber = i });
            }
            Start();
        }
        private void Start()
        {
            _currentTarget = null;
            foreach (var bm in ButtonsCollection)
            {
                bm.IsCurrentTarget = bm.IsReached = false;
            }
            ExcludedItems.Clear();
            _rnd = new Random(DateTime.Now.Second);
            _timer = new Timer(OnTargetChanged, null, 0, 1000);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ButtonModel> ButtonsCollection
        {
            get { return _buttonsCollection; }
            set { _buttonsCollection = value; OnPropertyChanged(); }
        }
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Btn_candidate_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ButtonModel model = ((Button)sender).DataContext as ButtonModel;
            if (model != null && model.IsCurrentTarget && !ExcludedItems.Contains(model.ButtonNumber))
            {
                model.IsReached = true;
                ExcludedItems.Add(model.ButtonNumber);
            }
        }
        private void ChangeTarget()
        {
            var target = GetNextTarget();
            if (target == -1)
            {
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
                MessageBox.Show("All items have been reached ! Congratulations");
            }
            if (_currentTarget != null) _currentTarget.IsCurrentTarget = false;
            _currentTarget = ButtonsCollection[target];
            _currentTarget.IsCurrentTarget = true;
        }
        private int GetNextTarget()
        {
            if (ExcludedItems.Count == BTN_NUMBERS)
            {
                return -1;
            }
            var target = _rnd.Next(0, BTN_NUMBERS);
            if (ExcludedItems.Contains(target))
            {
                return GetNextTarget();
            }
            return target;
        }
        private void OnTargetChanged(object state)
        {
            this.Dispatcher.InvokeAsync(ChangeTarget);
        }
        private void Btn_startover_OnClick(object sender, RoutedEventArgs e)
        {
            Start();
        }
    }
