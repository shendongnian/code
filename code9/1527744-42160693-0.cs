    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Dictionary<int, string> cbTypeVals = new Dictionary<int, string>();
        private Dictionary<UInt16, string> cbSrcValueVals = new Dictionary<UInt16, string>();
        private Dictionary<UInt16, string> cbDiagVals = new Dictionary<UInt16, string>();
        public MainWindow()
        {
            InitializeComponent();
            _source = cbTypeVals;
	        //...
        }
        private System.Collections.IEnumerable _source;
        public System.Collections.IEnumerable Source
        {
            get { return _source; }
            set { _source = value; OnPropertyChanged(); }
        }
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Binding")
            {
                AutoCommitComboBoxColumn cb = new AutoCommitComboBoxColumn();
                e.Column = cb;
                
                //bind the ItemsSource property to the Source property of the window here...
                cb.SetBinding(AutoCommitComboBoxColumn.ItemsSourceProperty, new Binding("Source") { Source = this });
                cb.ItemsSource = cbSrcValueVals;
                cb.DisplayMemberPath = "Value";
                cb.SelectedValuePath = "Key";
                cb.SelectedValueBinding = new Binding("Binding");
                e.Column.Header = "Binding";
                e.Column.CellStyle = new Style(typeof(DataGridCell));
                e.Column.CellStyle.Setters.Add(new Setter(DataGridCell.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
            }
            //...
        }
        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //set the value of the Source property to a new collection and raise the PropertyChanged event here...
            Source = cbDiagVals;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
	
	    //...
    }
