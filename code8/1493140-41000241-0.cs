    public partial class MainWindow : Window
    {
        private Dictionary<string, bool> _myDict;
        public Dictionary<string, bool> MyDictionary
        {
            get
            {
                return _myDict;
            }
            set
            {
                _myDict = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            _myDict = new Dictionary<string, bool>();
            _myDict.Add("FirstBorder", true);
            DataContext = this;
	    }
    }
    
    <Button Content="Button" Width="30" Height="25" IsEnabled="{Binding MyDictionary[FirstBorder]}" />
