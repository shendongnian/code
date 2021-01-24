    public partial class MainWindow : Window
    {
        DataTable _dataTable;
        public MainWindow()
        {
            InitializeComponent();
            _dataTable = new DataTable();
            _dataTable.Columns.Add(new DataColumn("Name"));
            _dataTable.Columns.Add(new DataColumn("Id"));
            _dataTable.Rows.Add("First", "1");
            _dataTable.Rows.Add("Second", "2");
            myGrid.ItemsSource = _dataTable.DefaultView;
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = txtSearch.Text;
            if (string.IsNullOrEmpty(filter))
                _dataTable.DefaultView.RowFilter = null;
            else
                _dataTable.DefaultView.RowFilter = string.Format("Name Like '%{0}%' OR Id Like '%{0}%'", filter);
        }
    }
