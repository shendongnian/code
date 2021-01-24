      private string _DirectoryList = "";
      public string DirectoryListAdd
        {
            get { return _DirectoryList; }
            set
            {
                    _DirectoryList=_DirectoryList.Insert(0, value + Environment.NewLine);
                    OnPropertyChanged("DirectoryListAdd");
            }
        }
      public MainWindow()
        {
            InitializeComponent();
            DirectoryListAdd = "a";
            DirectoryListAdd = "b";
            Console.WriteLine(DirectoryListAdd);
        }
