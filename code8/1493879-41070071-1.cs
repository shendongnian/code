        public ObservableCollection<DataGrid> QueryResults;
        public event PropertyChangedEventHandler PropertyChanged;
        public QueryResultsWindow(string _name, JObject _returns)
        {
            InitializeComponent();
            QueryNameText.Text = _name;
            QueryResults = new ObservableCollection<DataGrid>();
            JArray sets = (JArray)_returns.SelectToken("$..Set");
            foreach(JObject set in sets)
            {
                DataGrid dg = new DataGrid();
                QuerySet s = new QuerySet();
                s = JsonConvert.DeserializeObject<QuerySet>(set.ToString());
                s.GetDataGridTable();
                DataView newView = new DataView(s.BindableTable);
                dg.ItemsSource = newView;
                dg.CanUserAddRows = false;
                dg.CanUserDeleteRows = false;
                QueryResults.Add(dg);
            }
            ResultsListBox.ItemsSource = QueryResults;
        }
