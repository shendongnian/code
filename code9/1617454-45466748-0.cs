        public MainPage()
        {
            this.InitializeComponent();
        }
        public void page_Loaded(object sender, RoutedEventArgs e)
        {
            populateDdlMultiColor();
            comboBoxColor.SelectedValue = ColorInt(Colors.Red);
        }
        private void populateDdlMultiColor()
        {
            comboBoxColor.ItemsSource = ColorDict();
            comboBoxColor.DisplayMemberPath = "Key";
            comboBoxColor.SelectedValuePath = "Value";
            
           
        }
        private Dictionary<string,int> ColorDict()
        {
            Dictionary<string, int> L = new Dictionary<string, int>();
            L.Add("reddish",ColorInt(Colors.Red));
            return L;
        }
        private int ColorInt(Color c)
        {
            return (c.A*16777216) + (c.R*65536) + (c.G*256) + c.B ;
        }
