        public MainWindow()
        {
            InitializeComponent();
            Colls = new ObservableCollection<MyClass>();
            Colls.Add(new MyClass()
            {
                Id = "1", Name = "aaa"
            });
            Colls.Add(new MyClass()
            {
                Id = "2",
                Name = "bbb"
            });
            Colls.Add(new MyClass()
            {
                Id = "3",
                Name = "ccc"
            });
            this.DataContext = this;
        }
        private ObservableCollection<MyClass> _colls;
        public ObservableCollection<MyClass> Colls
        {
            get { return _colls; }
            set { _colls = value; }
        }
        private int i = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Colls[0].Name = "Value changed for " + i++ + " time(s).";
        }
