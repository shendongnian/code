        public string SearchTextBoxText
        {
            get { return SearchTextBox.Text; }
            set { SearchTextBox.Text = value; }
        }
        public object SearchButtonContent
        {
            get { return SearchButton.Content; }
            set { SearchButton.Content = value; }
        }
        public event RoutedEventHandler SearchButton_Clicked;
        public UserControl1()
        {
            InitializeComponent();
	     SearchButton_Clicked += SearchButton_Click;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchButton_Clicked != null)
            {
                SearchButton_Clicked(sender, e);
            }
        }
    }  
