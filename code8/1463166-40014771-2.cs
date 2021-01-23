        private List<MessagesCollection> messagesCollectionView = new List<MessagesCollection>();
        public List<MessagesCollection> MessageSource
        {
            get
            {
                return messagesCollectionView;
            }
            set
            {
                messagesCollectionView = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MessageSource.Add(new MessagesCollection { Content = "test content", Title = "header" });
        }
