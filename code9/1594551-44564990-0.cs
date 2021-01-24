        public MainWindow()
        {
            InitializeComponent();
            WB_1.Navigate(@"https://www.instagram.com/" + Console.ReadLine() + @"/?hl=en");
            WB_1.LoadCompleted += wb_LoadCompleted;
        }
        void wb_LoadCompleted(object sender, NavigationEventArgs e)
        {
            dynamic doc = WB_1.Document;
            string htmlText = doc.documentElement.InnerHtml;
        }
