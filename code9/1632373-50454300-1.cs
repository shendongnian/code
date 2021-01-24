        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public bool ShowLabel
        {
            get
            {
                return !(Items.Count > 0);
            }
        }
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                
            }
        }
        public MainPage()
		{
			InitializeComponent();          
            TheListView.ItemsSource = _items;
            BindingContext = this;
        }
        private void btnAddItem_Clicked(object sender, EventArgs e)
        {
            Items.Add("Add a item");
            NotifyPropertyChanged("ShowLabel");            
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
