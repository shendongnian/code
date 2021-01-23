    public partial class Home : UserControl
    {
        public ObservableCollection<TableClass> tcc { get; set; }
        public Home()
        {
            InitializeComponent();
            tcc = new ObservableCollection<TableClass>();
            DataContext = this;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TableClass tc;
            List<TableClass> tcl = new List<TableClass>();
            tcc.CollectionChanged += tcc_CollectionChanged;
            for (int i = 0; i < 10; i++)
            {
                tc = new TableClass();
                tc.AGNR.Name = "AGNr";
                tc.AGNR.Value = i.ToString();
                tc.MNR.Name = "MNr";
                tc.MNR.Value = i.ToString() + " M";
                tc.MST.Name = "MSt";
                tc.MST.Value = i % 2 == 0 ? "production" : "stopped";
                tcc.Add(tc);
            }
        }
        static void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + ", Property changed");
            return;
        }
        static void tcc_CollectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + ", Collection changed");
            return;
        }
    }
    public class TableClass : INotifyPropertyChanged
    {
        private KeyValueClass _mnr;
        private KeyValueClass _agnr;
        private KeyValueClass _mst;
        public KeyValueClass MNR
        {
            get
            {
                return _mnr;
            }
            set
            {
                _mnr = value;
                NotifyPropertyChanged("MNR");
            }
        }
        public KeyValueClass AGNR
        {
            get
            {
                return _agnr;
            }
            set
            {
                _agnr = value;
                NotifyPropertyChanged("AGNR");
            }
        }
        public KeyValueClass MST
        {
            get
            {
                return _mst;
            }
            set
            {
                _mst = value;
                NotifyPropertyChanged("MST");
            }
        }
        public TableClass()
        {
            MNR = new KeyValueClass();
            AGNR = new KeyValueClass();
            MST = new KeyValueClass();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class KeyValueClass
    {
        private string _name;
        private string _val;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Value
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }
    }
